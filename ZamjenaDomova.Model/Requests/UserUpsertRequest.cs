using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ZamjenaDomova.Model.Requests
{
    public class UserUpsertRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] Image { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
