using Microsoft.AspNetCore.Mvc;
using ReportingService.IServices;
using ReportingService.Model;
using ReportingService.Services;


namespace ReportingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsService _reports;
        private readonly NLogReportService _logger;
        public ReportsController(IReportsService reportsIService,NLogReportService logger)
        {
            _logger = logger;
            _reports = reportsIService;


        }
        [HttpGet]
        [Route("GetReportTemplates")]
        public Task<List<ReportTemplate>> GetReportTemplates()
        {
            _logger.LogInfo("ReportsController", "GetReportTemplate", "----------Start----------");
            Task<List<ReportTemplate>> report_Templates = null!;
            try
            {
                report_Templates = _reports.GetReportTemplates()!;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
            _logger.LogInfo("ReportsController", "GetReportTemplate", "----------End----------");
            return report_Templates!;

        }
        [HttpGet("GetColumnNames")]
        public Task<List<ColumnInfo>> GetColumnNames(string Module)
        {
            _logger.LogInfo("ReportsController", "GetColumnNames", "----------Start----------");
            Task<List<ColumnInfo>> columnInfos = null!;
            try
            {
                columnInfos = _reports.GetColumnNames(Module);

            }
            catch (Exception ex)
            {
                _logger.LogInfo( ex.Message);
            }
            _logger.LogInfo("ReportsController", "GetColumnNames", "----------End----------");
            return columnInfos!;

        }
        [HttpGet("GetTemplateList")]
        public Task<List<TemplateList>> GetTemplateList(string Module)
        {
            _logger.LogInfo("ReportsController", "GetColumnNames", "----------Start----------");
            Task<List<TemplateList>> templateLists = null!;
            try
            {
                templateLists = _reports.GetTemplateList(Module);

            }
            catch (Exception ex)
            {
                _logger.LogInfo(ex.Message);
            }
            _logger.LogInfo("ReportsController", "GetColumnNames", "----------End----------");
            return templateLists!;

        }
        [HttpGet("GetTemplateData")]
        public ConsentEventReport GetTemplateData(int templateId, string Module)
        {
            _logger.LogInfo("ReportsController", "GetTemplateData", "----------Start----------");
            ConsentEventReport consentEvent = new ConsentEventReport();
            try
            {
                consentEvent = _reports.GetTemplateData(templateId, Module);
            }
            catch (Exception ex)
            {
                _logger.LogInfo(ex.Message);
            }
            _logger.LogInfo("ReportsController", "GetTemplateData", "----------End----------");
            return consentEvent;

        }
        [HttpGet("DeleteTemplate")]
        public int DeleteTemplate(int templateId, string Module)
        {
            return _reports.DeleteTemplate(templateId, Module);
        }
        [HttpPost("SaveReportTemplate")]
        public string SaveReportTemplate([FromBody] ConsentEventReport ConsentEventReport)
        {
            _logger.LogInfo("ReportsController", "SaveReportTemplate", "----------Start----------");
            string result = "";
            try
            {
                result = _reports.SaveReportTemplate(ConsentEventReport);
            }
            catch (Exception ex)
            {
                _logger.LogInfo(ex.Message);
            }
            _logger.LogInfo("ReportsController", "SaveReportTemplate", "----------End----------");
            return result;
        }
        [HttpPost("GenerateConsentReport")]
        public Task<List<dynamic>> GenerateConsentReport([FromBody] ConsentReportFields ReportFilter)
        {
            return _reports.GenerateOriginatorReport(ReportFilter);
        }

    }
}
