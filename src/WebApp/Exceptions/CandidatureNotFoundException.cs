using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Exceptions
{
    internal class CandidatureNotFoundException : Exception
    {
        public CandidatureNotFoundException() : base("Candidature introuvable.")
        {

        }
    }
}
