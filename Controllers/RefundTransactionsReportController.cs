using Microsoft.AspNetCore.Mvc;
using ReportingService.IServices;
using ReportingService.Model;

namespace ReportingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RefundTransactionsReportController : Controller
    {
        private readonly IRefundTransactionsReportService _reportService;
        private readonly ILogger<RefundTransactionsReportController> _logger;

        public RefundTransactionsReportController(IRefundTransactionsReportService reportService,
            ILogger<RefundTransactionsReportController> logger)
        {
            _reportService = reportService;
            _logger = logger;
        }

        [HttpPost("GetRefundTransactionsReport")]
        public async Task<IActionResult> GetRefundTransactionsReportAsync([FromBody] RefundTransactionsReportFilter filter)
        {
            var result = await _reportService.GetRefundTransactionsReportAsync(filter);
            return Ok(result);
        }
    }
}
