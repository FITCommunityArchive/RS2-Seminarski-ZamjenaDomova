using AutoMapper;
using ZamjenaDomova.Model;
using ZamjenaDomova.Model.Requests;
using ZamjenaDomova.WebAPI.Database;
using ZamjenaDomova.WebAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZamjenaDomova.WebAPI.Helpers;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace ZamjenaDomova.WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ZamjenaDomovaContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserService(ZamjenaDomovaContext context, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public List<Model.User> Get(UserSearchRequest request)
        {
            var query = _context.User.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Name))
                query = query.Where(x => x.FirstName.StartsWith(request.Name) || x.LastName.StartsWith(request.Name));

            var list = query.ToList();

            return _mapper.Map<List<Model.User>>(list);
        }
        public Model.User GetById(int id)
        {
            var user = _context.User.FirstOrDefault(x => x.UserId == id);

            if (user == null)
                return new Model.User();

            var result = new Model.User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Image = user.Image,
                PhoneNumber = user.PhoneNumber,
                UserId=user.UserId
            };

            var userRoles = _context.UserRole.Where(x => x.UserId == id);
            if(userRoles.Count() >0)
            {
                result.Roles = new List<Model.Role>();
                foreach (var role in userRoles.Include(x => x.Role))
                    result.Roles.Add(new Model.Role { RoleId = role.RoleId, Name = role.Role.Name });
            }
            return result;
        }

        public Model.User Insert(UserUpsertRequest request)
        {
            if (_context.User.Any(x => x.Email == request.Email))
            {
                throw new UserException("Email \"" + request.Email + "\" je već zauzet!");
            }
            var entity = _mapper.Map<Database.User>(request);

            if (request.Password != request.PasswordConfirmation)
                throw new UserException("Lozinke se ne podudaraju!");

            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);

            _context.User.Add(entity);
            _context.SaveChanges();

            var wishlist = new Database.Wishlist { UserId = entity.UserId };
            _context.Wishlist.Add(wishlist);
            _context.SaveChanges();
            
            if (request.Roles != null && request.Roles.Count() > 0 && request.Roles[0] != 0)
            {
                foreach (var role in request.Roles)
                {
                    _context.UserRole.Add(new UserRole
                    {
                        RoleId = role,
                        UserId = entity.UserId
                    });
                }
            }
            _context.SaveChanges();
            return _mapper.Map<Model.User>(entity);
        }
        public Model.User Update(int id, [FromBody] UserUpsertRequest request)
        {
            var entity = _context.User.Include(x => x.UserRoles).FirstOrDefault(x => x.UserId == id);
            
            _context.User.Attach(entity);
            _context.User.Update(entity);

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordConfirmation)
                    throw new Exception("Passwordi se ne slažu");
                entity.PasswordSalt = GenerateSalt();
                entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);
            }
            _mapper.Map(request, entity);

            _context.SaveChanges();
            var userRoles = _context.UserRole.Where(x => x.UserId == entity.UserId);
            if (request.Roles.Count() < userRoles.Count())
            {
                foreach (var role in userRoles)
                {
                    if (!request.Roles.Contains(role.RoleId))
                    {
                        _context.UserRole.Remove(role);
                    }
                }
            }

            if (request.Roles != null && request.Roles.Count() > 0 && request.Roles[0] != 0)
            {
                foreach (var role in request.Roles)
                {
                    if (!_context.UserRole.Any(x => x.UserId == entity.UserId && x.RoleId == role))
                    {
                        _context.UserRole.Add(new UserRole
                        {
                            RoleId = role,
                            UserId = entity.UserId
                        });
                    }
                }
            }
            _context.SaveChanges();
            return _mapper.Map<Model.User>(entity);
        }
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public Model.UserResponse Authenticate(string email, string password)
        {
            var user = _context.User.Include("UserRoles.Role").FirstOrDefault(x => x.Email == email);

            if (user == null)
                return null;

            var newHash = GenerateHash(user.PasswordSalt, password);
            if (newHash == user.PasswordHash)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                };

                foreach (var role in user.UserRoles)
                {
                    var claim = new Claim(ClaimTypes.Role, role.Role.Name);
                    claims.Add(claim);
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                var loggedUser = new Model.UserResponse
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Token = tokenString,
                    Token_Expiration_Time = token.ValidTo,
                    WishlistId = _context.Wishlist.First(x => x.UserId == user.UserId).WishlistId
                };

                return loggedUser;
            }

            return null;
        }
        public Model.User ChangePassword(string userEmail, ChangePasswordModel model)
        {
            var user = _context.User.FirstOrDefault(u => u.Email == userEmail);

            if (user == null)
            {
                throw new UserException("Korisnik nije pronađen!");
            }

            var oldHash = GenerateHash(user.PasswordSalt, model.OldPassword);
            if (oldHash != user.PasswordHash)
            {
                throw new UserException("Stara lozinka nije ispravna!");
            }

            user.PasswordHash = GenerateHash(user.PasswordSalt, model.NewPassword);
            _context.SaveChanges();
            return _mapper.Map<Model.User>(user);
        }

        public Model.User Delete(int id)
        {
            var entity = _context.User.Find(id);

            _context.User.Remove(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.User>(entity);
        }

        public Model.User ChangeProfilePicture(string userEmail, byte[] imageArray)
        {
            var user = _context.User.FirstOrDefault(u => u.Email == userEmail);

            if (user == null)
            {
                throw new UserException("Korisnik nije pronađen!");
            }
            user.Image = imageArray;
            _context.SaveChanges();
            return _mapper.Map<Model.User>(user);
        }

        public Model.User UpdateAccountSettings(int id, AccountSettingsUpdateRequest request)
        {
            var entity = _context.User.FirstOrDefault(x => x.UserId == id);

            _context.User.Attach(entity);
            _context.User.Update(entity);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.User>(entity);
        }
    }
}
