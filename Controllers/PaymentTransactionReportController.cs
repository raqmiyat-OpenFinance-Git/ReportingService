using Microsoft.AspNetCore.Mvc;
using ReportingService.IServices;
using ReportingService.Model;

namespace ReportingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTransactionReportController : ControllerBase
    {
        private readonly IPaymentTransactionReportService _reportService;

        public PaymentTransactionReportController(
            IPaymentTransactionReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost("GetPaymentTransactionReport")]
        public async Task<IActionResult> GetPaymentTransactionReport(
            [FromBody] PaymentTransactionReportFilter filter)
        {
            try
            {
                var reportData =
                    await _reportService.GetPaymentTransactionReportAsync(filter);

                if (reportData == null || reportData.Count == 0)
                {
                    return NotFound(
                        "No data found for the given filter.");
                }

                return Ok(reportData);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    $"Internal server error: {ex.Message}");
            }
        }
    }
}
