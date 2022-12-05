using System.IO;
using System.Linq;
using WebApp.Services.Intrefaces;

namespace WebApp.Services
{
    public class FileExtensionValidatorService : IFileExtensionValidatorService
    {
        public bool IsValid(string fileName, string[] allewedExtensions)
        {
            var extension = Path.GetExtension(fileName);
            return !allewedExtensions.Contains(extension.ToLower()) ? false : true;

        }
    }
}
