using Microsoft.AspNetCore.Mvc;
using ReportingService.Model;

namespace ReportingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BulkBatchPaymentReportController : Controller
    {
        private readonly IBulkBatchPaymentReportService _reportService;
        private readonly ILogger<BulkBatchPaymentReportController> _logger;

        public BulkBatchPaymentReportController(IBulkBatchPaymentReportService reportService,
            ILogger<BulkBatchPaymentReportController> logger)
        {
            _reportService = reportService;
            _logger = logger;
        }

        [HttpPost("GetBulkBatchPaymentReport")]
        public async Task<IActionResult> GetBulkBatchPaymentReportAsync([FromBody] BullkBatchPaymentReportFilter query)
        {
            var result = await _reportService.GetBulkBatchPaymentReportAsync(query);
            return Ok(result);
        }
    }
}
