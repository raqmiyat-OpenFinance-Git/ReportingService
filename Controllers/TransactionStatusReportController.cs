using Microsoft.AspNetCore.Mvc;
using ReportingService.IServices;
using ReportingService.Model;

namespace ReportingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionStatusReportController : ControllerBase
    {
        private readonly ITransactionStatusReportService _reportService;

        public TransactionStatusReportController(ITransactionStatusReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost("GetTransactionStatusReport")]
        public async Task<IActionResult> GetTransactionStatusReport([FromBody] TransactionStatusReportFilter filter)
        {
            try
            {
                var reportData = await _reportService.GetTransactionStatusReportAsync(filter);

                if (reportData == null || reportData.Count == 0)
                    return NotFound("No data found for the given filter.");

                return Ok(reportData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
