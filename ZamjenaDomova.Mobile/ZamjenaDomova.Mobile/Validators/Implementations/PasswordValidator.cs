using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ZamjenaDomova.Mobile.Validators.Contracts;

namespace ZamjenaDomova.Mobile.Validators.Implementations
{
    public class PasswordValidator :IValidator
    {
        public string Message { get; set; } = "Lozinka mora biti duga 8 znakova, barem jedno slovo i jedan broj";
        public string Format = "^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$";

        public bool Check(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                Regex format = new Regex(Format);

                return format.IsMatch(value);
            }
            else
            {
                return false;
            }
        }
    }
}
