using System;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services.Intrefaces
{
    public interface ICandidaturesService
    {
        Task<DataTableModel> GetCandidaturesAsync(int length, int start, string search);
        Task DeleteCandidatureByIdAsync(Guid id);
        Task<Guid> CreateCandidatureInfoAsync(CandidaturePersonalInfoModel candidatureModel);
        Task AddCvToCandidatureAsync(UploadCVModel uploadCVModel);
        Task<DetailModel> GetCondidatureDetailAsync(Guid id);
    }
}
