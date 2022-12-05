namespace WebApp.Services.Intrefaces
{
    public interface IFileExtensionValidatorService
    {
        bool IsValid(string extension, string[] allewedExtensions);
    }
}
