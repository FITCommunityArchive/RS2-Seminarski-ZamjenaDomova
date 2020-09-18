using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ZamjenaDomova.Model
{
    public class ChangePasswordModel
    {
        public string OldPassword { get; set; }
        [MinLength(8)]
        public string NewPassword { get; set; }
        [Compare("NewPassword")]
        public string PasswordConfirmation { get; set; }
    }
}
