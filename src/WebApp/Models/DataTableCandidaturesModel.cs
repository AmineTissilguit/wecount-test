using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class DataTableCandidaturesModel
    {
        public string Id { get; set; }
        public string NomComplet { get; set; }
        public DateTime DateEnvoi { get; set; }
        public string CV { get; set; }
        public string Tele { get; set; }
    }
}
