using System.Linq;
using WebApp.Services.Intrefaces;

namespace WebApp.Services
{
    public class FileExtensionValidatorService : IFileExtensionValidatorService
    {
        public bool IsValid(string extension, string[] allewedExtensions)
        {
            return allewedExtensions.Contains(extension.ToLower()) ? true : false;
        }
    }
}
