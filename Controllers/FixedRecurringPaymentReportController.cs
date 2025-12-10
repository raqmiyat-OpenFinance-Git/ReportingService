using Microsoft.AspNetCore.Mvc;
using ReportingService.IServices;
using ReportingService.Model;

namespace ReportingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FixedRecurringPaymentReportController : Controller
    {
        private readonly IFixedRecurringPaymentReportService _reportService;
        private readonly ILogger<FixedRecurringPaymentReportController> _logger;

        public FixedRecurringPaymentReportController(IFixedRecurringPaymentReportService reportService,
            ILogger<FixedRecurringPaymentReportController> logger)
        {
            _reportService = reportService;
            _logger = logger;
        }

        [HttpPost("GetFixedRecurringPaymentReport")]
        public async Task<IActionResult> GetFixedRecurringPaymentReportAsync([FromBody] FixedRecurringPaymentReportFilter query)
        {
            var result = await _reportService.GetFixedRecurringPaymentReportAsync(query);
            return Ok(result);
        }
    }
}
