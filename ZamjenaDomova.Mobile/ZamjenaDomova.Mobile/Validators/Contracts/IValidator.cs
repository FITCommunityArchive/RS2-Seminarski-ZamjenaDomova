using System;
using System.Collections.Generic;
using System.Text;

namespace ZamjenaDomova.Mobile.Validators.Contracts
{
    public interface IValidator
    {
        string Message { get; set; }
        bool Check(string value);
    }
}
