using Microsoft.AspNetCore.Mvc;
using ReportingService.IServices;
using ReportingService.Model;

namespace ReportingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AccountBalanceSummaryReportController : Controller
    {


        private readonly IAccountBalanceSummaryReportService _reportService;
        private readonly ILogger<AccountBalanceSummaryReportController> _logger;

        public AccountBalanceSummaryReportController(
            IAccountBalanceSummaryReportService reportService,
            ILogger<AccountBalanceSummaryReportController> logger
        )
        {
            _reportService = reportService;
            _logger = logger;
        }

        [HttpPost("GetAccountBalanceSummaryReport")]
        public async Task<IActionResult> GetAccountBalanceSummaryReportAsync([FromBody] AccountBalanceSummaryReportFilter query)
        {
            var result = await _reportService.GetAccountBalanceSummaryReportAsync(query);
            return Ok(result);
        }
    }
}
