using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ZamjenaDomova.Model
{
    public class AuthenticateModel
    {
        [Required]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
