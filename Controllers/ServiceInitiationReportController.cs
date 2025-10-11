using Microsoft.AspNetCore.Mvc;
using ReportingService.IServices;
using ReportingService.Model;
using ReportingService.Services;

namespace ReportingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceInitiationReportController : ControllerBase
    {
        private readonly IServiceInitiationReportService _reports;
        private readonly NLogReportService _logger;
        public ServiceInitiationReportController(IServiceInitiationReportService reportsIService, NLogReportService logger)
        {
            _logger = logger;
            _reports = reportsIService;
        }
        [HttpGet]
        [Route("GetServiceInitiationReportTemplates")]
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
        [HttpGet("GetServiceInitiationColumnNames")]
        public Task<List<ColumnInfo>> GetColumnNames()
        {
            _logger.LogInfo("ReportsController", "GetColumnNames", "----------Start----------");
            Task<List<ColumnInfo>> columnInfos = null!;
            try
            {
                columnInfos = _reports.GetColumnNames();

            }
            catch (Exception ex)
            {
                _logger.LogInfo(ex.Message);
            }
            _logger.LogInfo("ReportsController", "GetColumnNames", "----------End----------");
            return columnInfos!;

        }
        [HttpGet("GetServiceInitiationTemplateList")]
        public Task<List<TemplateList>> GetTemplateList()
        {
            _logger.LogInfo("ReportsController", "GetColumnNames", "----------Start----------");
            Task<List<TemplateList>> templateLists = null!;
            try
            {
                templateLists = _reports.GetTemplateList();

            }
            catch (Exception ex)
            {
                _logger.LogInfo(ex.Message);
            }
            _logger.LogInfo("ReportsController", "GetColumnNames", "----------End----------");
            return templateLists!;

        }
        [HttpGet("GetServiceInitiationTemplateData")]
        public ServiceInitiationReport GetTemplateData(int templateId)
        {
            _logger.LogInfo("ReportsController", "GetTemplateData", "----------Start----------");
            ServiceInitiationReport serviceInitiationReport = new ServiceInitiationReport();
            try
            {
                serviceInitiationReport = _reports.GetTemplateData(templateId);
            }
            catch (Exception ex)
            {
                _logger.LogInfo(ex.Message);
            }
            _logger.LogInfo("ReportsController", "GetTemplateData", "----------End----------");
            return serviceInitiationReport;

        }
        [HttpGet("ServiceInitiationDeleteTemplate")]
        public int DeleteTemplate(int templateId)
        {
            return _reports.DeleteTemplate(templateId);
        }
        [HttpPost("SaveServiceInitiationReportTemplate")]
        public string SaveReportTemplate([FromBody] ServiceInitiationReport serviceInitiationReport)
        {
            _logger.LogInfo("ReportsController", "SaveReportTemplate", "----------Start----------");
            string result = "";
            try
            {
                result = _reports.SaveReportTemplate(serviceInitiationReport);
            }
            catch (Exception ex)
            {
                _logger.LogInfo(ex.Message);
            }
            _logger.LogInfo("ReportsController", "SaveReportTemplate", "----------End----------");
            return result;
        }

        [HttpPost("GenerateServiceInitiationReport")]
        public Task<List<dynamic>> GenerateServiceInitiationReport([FromBody] ServiceIntiationReportFields serviceInitiationReport)
        {
            return _reports.GenerateServiceInitiationReport(serviceInitiationReport);
        }
    }
}
