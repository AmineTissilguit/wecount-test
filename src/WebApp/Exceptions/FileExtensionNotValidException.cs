using System;

namespace WebApp.Exceptions
{
    public class FileExtensionNotValidException : Exception
    {
        public FileExtensionNotValidException()
            : base($"Extension de fichier téléchargée non valide")
        {

        }
    }
}
