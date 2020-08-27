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

namespace ZamjenaDomova.WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ZamjenaDomovaContext _context;
        private readonly IMapper _mapper;

        public UserService(ZamjenaDomovaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.User> Get(UserSearchRequest request)
        {
            var query = _context.User.AsQueryable();

            if(!string.IsNullOrWhiteSpace(request?.FirstName))
                query = query.Where(x => x.FirstName.StartsWith(request.FirstName));
            
            if(!string.IsNullOrWhiteSpace(request?.LastName))
                query = query.Where(x => x.LastName.StartsWith(request.LastName));
            
            var list = query.ToList();

            return _mapper.Map<List<Model.User>>(list);
        }

        public Model.User Insert(UserInsertRequest request)
        {
            var entity = _mapper.Map<Database.User>(request);

            if (request.Password != request.PasswordConfirmation)
                throw new UserException("Passwords do not match!");

            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);

            _context.User.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.User>(entity); 
        }
        Model.User IUserService.Update(int id, [FromBody]UserUpdateRequest request)
        {
            var entity = _context.User.Find(id);

            _mapper.Map(request, entity);

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

        
    }
}
