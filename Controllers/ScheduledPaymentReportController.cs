using Microsoft.AspNetCore.Mvc;
using ReportingService.IServices;
using ReportingService.Model;

namespace ReportingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduledPaymentReportController : Controller
    {
        private readonly IScheduledPaymentReportService _scheduledPaymentReportService;
        private readonly ILogger<ScheduledPaymentReportController> _logger;

        public ScheduledPaymentReportController(IScheduledPaymentReportService scheduledPaymentReportService,
            ILogger<ScheduledPaymentReportController> logger)
        {
            _scheduledPaymentReportService = scheduledPaymentReportService;
            _logger = logger;
        }

        [HttpPost("GetScheduledPaymentReport")]
        public async Task<IActionResult> GetScheduledPaymentReportAsync([FromBody] ScheduledPaymentReportFilter query)
        {
            try
            {
                var result = await _scheduledPaymentReportService.GetScheduledPaymentReportAsync(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching Scheduled Payment Report");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}
