using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services.Intrefaces
{
    public interface ICandidaturesService
    {
        Task<DataTableModel> GetCandidaturesAsync(int length, int start, string search);
        Task DeleteCandidatureById(Guid id);

    }
}
