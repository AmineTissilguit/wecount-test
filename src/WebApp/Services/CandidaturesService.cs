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

        public async Task CreateCandidatureAsync(CandidatureForCreationModel candidatureModel)
        {

            string[] allowedExtensions = { ".jpg", ".png", ".pdf" };

            var extension = Path.GetExtension(candidatureModel.UploadedCV.FileName);

            // Validate file extension
            if (!_fileExtensionValidatorService.IsValid(extension, allowedExtensions))
            {
                throw new FileExtensionNotValidException();
            }

            // upload the file to the server
            var fileName = $"{candidatureModel.Nom}-{candidatureModel.Prenom}-{Guid.NewGuid()}{extension}";

            var path = Path.Combine(_webHostEnvironment.WebRootPath, "CV", fileName);

            using FileStream fileStream = new(path, FileMode.Create);

            candidatureModel.UploadedCV.CopyTo(fileStream);

            // save the candidature in database
            var candidature = new Candidature()
            {
                AnneeExperience = candidatureModel.AnneeExperience,
                Id = Guid.NewGuid(),
                Nom = candidatureModel.Nom,
                Prenom = candidatureModel.Prenom,
                Mail = candidatureModel.Mail,
                CV = $"/CV/{fileName}",
                Telephone = candidatureModel.Telephone,
                DernierEmployeur = candidatureModel.DernierEmployeur,
                NiveauEtude = candidatureModel.NiveauEtude
            };


            _context.Add(candidature);
            await _context.SaveChangesAsync();

        }


    }
}
