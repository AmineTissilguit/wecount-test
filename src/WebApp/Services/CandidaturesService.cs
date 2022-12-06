using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.EfClasses;
using WebApp.Data.EfCode;
using WebApp.Exceptions;
using WebApp.Models;
using WebApp.Services.Intrefaces;

namespace WebApp.Services
{
    public class CandidaturesService : ICandidaturesService
    {
        private readonly AppDbContext _context;
        private readonly IFileExtensionValidatorService _fileExtensionValidatorService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CandidaturesService(AppDbContext context, IFileExtensionValidatorService fileExtensionValidatorService, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _fileExtensionValidatorService = fileExtensionValidatorService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<DataTableModel> GetCandidaturesAsync(int length, int start, string search)
        {
            var dataTableModel = new DataTableModel();

            var candidatures = _context.Candidatures.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                candidatures = candidatures.Where(x => x.Nom.ToLower().Contains(search)
                                        || x.Prenom.ToLower().Contains(search)
                                        || x.Telephone.ToLower().Contains(search));
            }

            dataTableModel.Candidatures = await candidatures.Skip(start)
                                                            .Take(length)
                                                            .OrderByDescending(x => x.CreatedOn)
                                                            .Select(x => new DataTableCandidaturesModel()
                                                            {
                                                                Id = x.Id.ToString(),
                                                                CV = x.CV,
                                                                DateEnvoi = x.CreatedOn.ToString("dd/MM/yyyy hh:mm:ss"),
                                                                NomComplet = x.Prenom + " " + x.Nom,
                                                                Tele = x.Telephone
                                                            })
                                                            .ToListAsync();

            dataTableModel.RecordsTotal = candidatures.Count();
            dataTableModel.RecordsFiltered = candidatures.Count();

            return dataTableModel;

        }

        public async Task DeleteCandidatureByIdAsync(Guid Id)
        {
            var candidature = await _context.Candidatures.Where(x => x.Id == Id).FirstOrDefaultAsync();

            if (candidature is null)
            {
                throw new CandidatureNotFoundException();
            }

            _context.Candidatures.Remove(candidature);

            await _context.SaveChangesAsync();
        }

        public async Task<Guid> CreateCandidatureInfoAsync(CandidaturePersonalInfoModel candidatureModel)
        {
            // create a new guid
            var id = Guid.NewGuid();
            while (await _context.Candidatures.AnyAsync(x => x.Id == id))
            {
                id = Guid.NewGuid();
            }

            // create candidature entity
            var candidature = new Candidature()
            {
                AnneeExperience = candidatureModel.AnneeExperience,
                Id = id,
                Nom = candidatureModel.Nom,
                Prenom = candidatureModel.Prenom,
                Mail = candidatureModel.Mail,
                CV = "/CV/test01.pdf",
                Telephone = candidatureModel.Telephone,
                DernierEmployeur = candidatureModel.DernierEmployeur,
                NiveauEtude = candidatureModel.NiveauEtude
            };


            // save candidature entity into database
            _context.Add(candidature);
            await _context.SaveChangesAsync();

            return candidature.Id;

        }


        public async Task AddCvToCandidatureAsync(UploadCVModel uploadCVModel)
        {
            var candidature = await _context.Candidatures.FirstOrDefaultAsync(x => x.Id == uploadCVModel.CandidatureId);

            if (candidature is null)
            {
                throw new CandidatureNotFoundException();
            }

            string[] allowedExtensions = { ".jpg", ".png", ".pdf" };

            var extension = Path.GetExtension(uploadCVModel.UploadedCV.FileName);

            // Validate file extension
            if (!_fileExtensionValidatorService.IsValid(extension, allowedExtensions))
            {
                throw new FileExtensionNotValidException();
            }

            // upload the file to the server
            var fileName = $"{candidature.Prenom}-{candidature}-{Guid.NewGuid()}{extension}";

            var path = Path.Combine(_webHostEnvironment.WebRootPath, "CV", fileName);

            using FileStream fileStream = new(path, FileMode.Create);

            uploadCVModel.UploadedCV.CopyTo(fileStream);

            // update the path of the cv
            candidature.CV = $"/CV/{fileName}";

            await _context.SaveChangesAsync();

        }


        public async Task<DetailModel> GetCondidatureDetailAsync(Guid id)
        {
            return await _context.Candidatures.AsNoTracking()
                                              .Where(x => x.Id == id)
                                              .Select(x => new DetailModel()
                                              {
                                                  AnneeExperience = x.AnneeExperience,
                                                  CV = x.CV,
                                                  DernierEmployeur = x.DernierEmployeur,
                                                  Mail = x.Mail,
                                                  NiveauEtude = x.NiveauEtude,
                                                  Nom = x.Nom,
                                                  Prenom = x.Prenom,
                                                  Telephone = x.Telephone
                                              })
                                              .FirstOrDefaultAsync();
        }
    }
}
