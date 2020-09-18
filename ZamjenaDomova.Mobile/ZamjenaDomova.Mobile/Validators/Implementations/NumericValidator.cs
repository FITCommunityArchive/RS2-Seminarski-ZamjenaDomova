using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ZamjenaDomova.Mobile.Validators.Contracts;

namespace ZamjenaDomova.Mobile.Validators.Implementations
{
    class NumericValidator : IValidator
    {
        public string Message { get; set; } = "Samo brojevi";
        public string Format = "^\\d$";

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
