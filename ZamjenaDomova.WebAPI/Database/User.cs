using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZamjenaDomova.WebAPI.Database
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public byte[] Image { get; set; }
        
    }
}
