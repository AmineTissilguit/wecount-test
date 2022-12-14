using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApp.Services.Intrefaces;

namespace WebApp.Controllers
{
    [Route("/candidature")]
    public class CandidatureController : Controller
    {
        private readonly ICandidaturesService _candidaturesService;
        public CandidatureController(ICandidaturesService candidaturesService)
        {
            _candidaturesService = candidaturesService;
        }

        [HttpPost("list")]
        public async Task<JsonResult> GetCandidaturesAsync(int length, int start)
        {
            var result = await _candidaturesService.GetCandidaturesAsync(length, start, Request.Form["search[value]"]);

            return Json(new { data = result.Candidatures, recordsTotal = result.RecordsTotal, recordsFiltered = result.RecordsFiltered });
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> DeleteCondidatureAync(Guid id)
        {
            try
            {
                await _candidaturesService.DeleteCandidatureByIdAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
