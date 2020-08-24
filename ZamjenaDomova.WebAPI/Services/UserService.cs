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

        public List<Model.User> Get()
        {
            return _mapper.Map<List<Model.User>>(_context.User.ToList());
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
