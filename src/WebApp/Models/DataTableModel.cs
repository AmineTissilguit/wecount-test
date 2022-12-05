using System.Collections.Generic;

namespace WebApp.Models
{
    public class DataTableModel
    {
        public IEnumerable<DataTableCandidaturesModel> Candidatures { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
    }
}
