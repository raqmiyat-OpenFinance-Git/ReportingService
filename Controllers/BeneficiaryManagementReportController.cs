using Microsoft.AspNetCore.Mvc;
using ReportingService.IServices;
using ReportingService.Model;

namespace ReportingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiaryManagementReportController : ControllerBase
    {
        private readonly IBeneficiaryManagementReportService _reportService;

        public BeneficiaryManagementReportController(IBeneficiaryManagementReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost("GetBeneficiaryManagementReport")]
        public async Task<IActionResult> GetBeneficiaryManagementReport([FromBody] BeneficiaryManagementReportFilter filter)
        {
            try
            {
                var reportData = await _reportService.GetBeneficiaryManagementReportAsync(filter);

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
