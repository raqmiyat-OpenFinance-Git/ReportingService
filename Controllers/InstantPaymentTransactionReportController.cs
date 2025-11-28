using Microsoft.AspNetCore.Mvc;
using ReportingService.IServices;
using ReportingService.Model;

namespace ReportingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstantPaymentTransactionReportController : Controller
    {
        private readonly IInstantPaymentTransactionReportService _service;
        public InstantPaymentTransactionReportController(IInstantPaymentTransactionReportService service)
        {
            _service = service;
        }

        [HttpPost("InstantPaymentTxnReport")]
        public async Task<IActionResult> GetInstantPaymentTransactionReport([FromBody] InstantPaymentTransactionQuery query)
        {
            var result = await _service.GetInstantPaymentTransactionReportAsync(query);
            return Ok(result);
        }
    }
}
