using Microsoft.AspNetCore.Mvc;
using System;
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
            Guid id = Guid.NewGuid();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                id = await _candidaturesService.CreateCandidatureInfoAsync(candidature);
            }
            catch (Exception)
            {
                ModelState.AddModelError("CreateCandidatureFailed", "Une erreur s'est produite, veuillez réessayer plus tard");

                return View();
            }

            var candidatureModel = new UploadCVModel()
            {
                CandidatureId = id
            };

            return RedirectToAction("GetUploadCVView", candidatureModel);
        }

        [HttpGet]
        public IActionResult GetUploadCVView(UploadCVModel uploadCVModel)
        {
            return View("UploadCV", uploadCVModel);
        }

        [HttpPost]
        public async Task<IActionResult> UploadCV([FromForm] UploadCVModel uploadCVModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await _candidaturesService.AddCvToCandidatureAsync(uploadCVModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AddCVFailed", ex.Message);

                return View("UploadCV");
            }

            return RedirectToAction("Detail", new { candidatureId = uploadCVModel.CandidatureId });
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid candidatureId)
        {
            return View(await _candidaturesService.GetCondidatureDetailAsync(candidatureId));
        }
    }
}
