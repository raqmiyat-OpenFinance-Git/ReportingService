using k8s.Models;
using Microsoft.AspNetCore.Mvc;
using ReportingService.IServices;
using ReportingService.Model;


namespace ReportingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ConfirmationPayeeReportController : Controller
    {
        private readonly IConfirmationPayeeReportService _reportService;
        private readonly ILogger<ConfirmationPayeeReportController> _logger;


        public ConfirmationPayeeReportController(
            IConfirmationPayeeReportService reportService,
            ILogger<ConfirmationPayeeReportController> logger)
        {
            _reportService = reportService;
            _logger = logger;
        }

        [HttpPost("ConfirmationofPayeeReport")]
        public async Task<IActionResult> GetConfirmationPayeeReportAsync([FromBody] ConfirmationPayeeQueryFilter query)
        {
            var result = await _reportService.GetConfirmationPayeeReportAsync(query);
            return Ok(result);
        }

     
    }
}
