using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services.Intrefaces
{
    public interface IFileExtensionValidatorService
    {
        bool IsValid(string extension, string[] allewedExtensions);
    }
}
