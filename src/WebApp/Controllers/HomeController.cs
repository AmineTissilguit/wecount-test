using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models;
using WebApp.Services.Intrefaces;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICandidaturesService _candidaturesService;
        public HomeController(ICandidaturesService candidaturesService)
        {
            _candidaturesService = candidaturesService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Candidatures()
        {
            return View();
        }

        [HttpPost("/condidatures")]
        public async Task<JsonResult> GetCandidaturesAsync(int length, int start)
        {
            var result = await _candidaturesService.GetCandidaturesAsync(length, start, Request.Form["search[value]"]);

            return Json(new { data = result.Candidatures, recordsTotal = result.RecordsTotal, recordsFiltered = result.RecordsFiltered });
        }

        [HttpGet("/delete/{id}")]
        public async Task<IActionResult> DeleteCondidature(Guid id)
        {
            try
            {
                await _candidaturesService.DeleteCandidatureById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
