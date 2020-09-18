using ZamjenaDomova.Mobile.Validators.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZamjenaDomova.Mobile.Validators.Implementations
{
    public class RequiredValidator : IValidator
    {
        public string Message { get; set; } = "Ovo polje je obavezno.";

        public bool Check(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
