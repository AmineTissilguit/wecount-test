using System;

namespace WebApp.Exceptions
{
    internal class CandidatureNotFoundException : Exception
    {
        public CandidatureNotFoundException() : base("Candidature introuvable.")
        {

        }
    }
}
