using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public CandidaturesService(AppDbContext context)
        {
            _context = context;
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
                                                            .Select(x => new DataTableCandidaturesModel()
                                                            {
                                                                Id = x.Id.ToString(),
                                                                CV = x.CV,
                                                                DateEnvoi = x.CreatedOn,
                                                                NomComplet = x.Prenom + " " + x.Nom,
                                                                Tele   = x.Telephone
                                                            })
                                                            .ToListAsync();

            dataTableModel.RecordsTotal = candidatures.Count();
            dataTableModel.RecordsFiltered = candidatures.Count();

            return dataTableModel;
            
        }

        public async Task DeleteCandidatureById(Guid Id)
        {
            //var candidature = await _context.Candidatures.Where(x => x.Id == Id).FirstOrDefaultAsync();

            //if(candidature is null)
            //{
            //    throw new CandidatureNotFoundException();
            //}

            //_context.Candidatures.Remove(candidature);

            //await _context.SaveChangesAsync();

            throw new CandidatureNotFoundException();
        }
    }
}
