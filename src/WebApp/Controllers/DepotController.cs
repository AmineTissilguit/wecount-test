using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services.Intrefaces;

namespace WebApp.Controllers
{
    public class DepotController : Controller
    {
        private readonly ICandidaturesService _candidaturesService;
        public DepotController(ICandidaturesService candidaturesService)
        {
            _candidaturesService = candidaturesService;
        }

        [HttpGet]
        public IActionResult CandidaturePersonalInfo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CandidaturePersonalInfo([FromForm] CandidaturePersonalInfoModel candidature)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await _candidaturesService.CreateCandidatureInfoAsync(candidature);
            }
            catch(Exception)
            {
                ModelState.AddModelError("CreateCandidatureFailed", "Une erreur s'est produite, veuillez réessayer plus tard");
            }


            return View();
        }
    }
}
