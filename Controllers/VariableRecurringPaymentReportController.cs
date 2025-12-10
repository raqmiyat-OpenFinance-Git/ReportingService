using Microsoft.AspNetCore.Mvc;
using ReportingService.IServices;
using ReportingService.Model;

namespace ReportingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VariableRecurringPaymentReportController : Controller
    {
        private readonly IVariableRecurringPaymentReportService _reportService;
        private readonly ILogger<VariableRecurringPaymentReportController> _logger;

        public VariableRecurringPaymentReportController(IVariableRecurringPaymentReportService reportService,
            ILogger<VariableRecurringPaymentReportController> logger
        )
        {
            _reportService = reportService;
            _logger = logger;
        }

        [HttpPost("GetVariableRecurringPaymentReport")]
        public async Task<IActionResult> GetVariableRecurringPaymentReportAsync([FromBody] VariableRecurringPaymentReportFilter query)
        {
            var result = await _reportService.GetVariableRecurringPaymentReportAsync(query);
            return Ok(result);
        }
    }
}
