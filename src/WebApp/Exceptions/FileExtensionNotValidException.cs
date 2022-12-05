using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Exceptions
{
    public class FileExtensionNotValidException : Exception
    {
        public FileExtensionNotValidException() 
            :base($"Extension de fichier téléchargée non valide")
        {

        }
    }
}
