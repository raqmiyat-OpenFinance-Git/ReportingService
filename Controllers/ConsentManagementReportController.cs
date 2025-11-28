using Microsoft.AspNetCore.Mvc;
using ReportingService.IServices;
using ReportingService.Model;

namespace ReportingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ConsentManagementReportController : Controller
    {
        private readonly IConsentManagementReportService _service;

        public ConsentManagementReportController(IConsentManagementReportService service)
        {
            _service = service;
        }

        [HttpPost("ConsentMgmtReport")]
        public async Task<IActionResult> GetConsentReport([FromBody] ConsentReportQuery query)
        {
            var result = await _service.GetConsentManagementReportAsync(query);
            return Ok(result);
        }
    }
}
