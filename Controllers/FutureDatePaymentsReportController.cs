using Microsoft.AspNetCore.Mvc;
using ReportingService.IServices;
using ReportingService.Model;

namespace ReportingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FutureDatePaymentsReportController : ControllerBase
    {
        private readonly IFutureDatePaymentsReportService _reportService;
        private readonly ILogger<FutureDatePaymentsReportController> _logger;

        public FutureDatePaymentsReportController(
            IFutureDatePaymentsReportService reportService,
            ILogger<FutureDatePaymentsReportController> logger)
        {
            _reportService = reportService;
            _logger = logger;
        }

        [HttpPost("GetFutureDatePaymentsReport")]
        public async Task<IActionResult> GetFutureDatePaymentsReportAsync([FromBody] FutureDatePaymentsReportFilter filter)
        {
            var result = await _reportService.GetFutureDatePaymentsReportAsync(filter);
            return Ok(result);
        }
    }
}
