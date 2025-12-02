using Microsoft.AspNetCore.Mvc;
using ReportingService.IServices;
using ReportingService.Model;


namespace ReportingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StandingOrderReportController : Controller
    {
        private readonly IStandingOrderReportService _standingOrderReportService;
        private readonly ILogger<StandingOrderReportController> _logger;

        public StandingOrderReportController( IStandingOrderReportService standingOrderReportService, ILogger<StandingOrderReportController> logger)
        {
            _standingOrderReportService = standingOrderReportService;
            _logger = logger;
        }

        [HttpPost("GetStandingOrderReport")]
        public async Task<IActionResult> GetStandingOrderReportAsync([FromBody] StandingOrderReportFilter query)
        {
            var result = await _standingOrderReportService.GetStandingOrderReportAsync(query);
            return Ok(result);
        }

    }
}
