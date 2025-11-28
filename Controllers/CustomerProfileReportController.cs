using Microsoft.AspNetCore.Mvc;
using ReportingService.IServices;
using ReportingService.Model;

namespace ReportingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CustomerProfileReportController : Controller
    {
        private readonly ICustomerProfileReportService _reportService;
        private readonly ILogger<CustomerProfileReportController> _logger;

        public CustomerProfileReportController(ICustomerProfileReportService reportService,ILogger<CustomerProfileReportController> logger)
        {
            _reportService = reportService;
            _logger = logger;
        }

        [HttpPost("GetCustomerProfileReport")]
        public async Task<IActionResult> GetCustomerProfileReportAsync([FromBody] CustomerProfileReportFilter query)
        {
            var result = await _reportService.GetCustomerProfileReportAsync(query);
            return Ok(result);
        }


    }
}
