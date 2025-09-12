using Microsoft.AspNetCore.Mvc;
using ReportingService.IServices;
using ReportingService.Model;
using ReportingService.Services;


namespace ReportingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataSharingReportController : ControllerBase
    {
        private readonly IDataSharingReportService _reports;
        private readonly NLogReportService _logger;
        public DataSharingReportController(IDataSharingReportService iDataSharingReportService, NLogReportService logger)
        {
            _logger = logger;
            _reports = iDataSharingReportService;


        }
        [HttpGet]
        [Route("GetDataSharingReportTemplates")]
        public Task<List<DataSharingReportTemplate>> GetDataSharingReportTemplates()
        {
            _logger.LogInfo("DataSharingReportController", "GetDataSharingReportTemplates", "----------Start----------");
            Task<List<DataSharingReportTemplate>> report_Templates = null!;
            try
            {
                report_Templates = _reports.GetDataSharingReportTemplates()!;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
            _logger.LogInfo("DataSharingReportController", "GetDataSharingReportTemplates", "----------End----------");
            return report_Templates!;

        }
        [HttpGet("GetDataSharingReportColumnNames")]
        public Task<List<DataSharingColumnInfo>> GetDataSharingReportColumnNames(string Module, string templateName)
        {
            _logger.LogInfo("DataSharingReportController", "GetDataSharingReportColumnNames", "----------Start----------");
            Task<List<DataSharingColumnInfo>> columnInfos = null!;
            try
            {
                columnInfos = _reports.GetDataSharingReportColumnNames(Module, templateName);

            }
            catch (Exception ex)
            {
                _logger.LogInfo(ex.Message);
            }
            _logger.LogInfo("DataSharingReportController", "GetDataSharingReportColumnNames", "----------End----------");
            return columnInfos!;

        }
        [HttpGet("GetDataSharingReportTemplateList")]
        public Task<List<DataSharingTemplateList>> GetDataSharingReportTemplateList(string Module)
        {
            _logger.LogInfo("DataSharingReportController", "GetDataSharingReportTemplateList", "----------Start----------");
            Task<List<DataSharingTemplateList>> templateLists = null!;
            try
            {
                templateLists = _reports.GetDataSharingReportTemplateList(Module);

            }
            catch (Exception ex)
            {
                _logger.LogInfo(ex.Message);
            }
            _logger.LogInfo("DataSharingReportController", "GetDataSharingReportTemplateList", "----------End----------");
            return templateLists!;

        }
        [HttpGet("GetDataSharingReportTemplateData")]
        public DataSharingReport GetDataSharingReportTemplateData(int templateId, string Module)
        {
            _logger.LogInfo("DataSharingReportController", "GetDataSharingReportTemplateData", "----------Start----------");
            DataSharingReport consentEvent = new DataSharingReport();
            try
            {
                consentEvent = _reports.GetDataSharingReportTemplateData(templateId, Module);
            }
            catch (Exception ex)
            {
                _logger.LogInfo(ex.Message);
            }
            _logger.LogInfo("DataSharingReportController", "GetDataSharingReportTemplateData", "----------End----------");
            return consentEvent;

        }
        [HttpGet("DataSharingReportDeleteTemplate")]
        public int DataSharingReportDeleteTemplate(int templateId, string Module)
        {
            return _reports.DataSharingReportDeleteTemplate(templateId, Module);
        }

        [HttpPost("SaveDataSharingReportTemplate")]
        public string SaveDataSharingReportTemplate([FromBody] DataSharingReport dataSharingReport)
        {
            _logger.LogInfo("DataSharingReportController", "SaveDataSharingReportTemplate", "----------Start----------");
            string result = "";
            try
            {
                result = _reports.SaveDataSharingReportTemplate(dataSharingReport);
            }
            catch (Exception ex)
            {
                _logger.LogInfo(ex.Message);
            }
            _logger.LogInfo("DataSharingReportController", "SaveDataSharingReportTemplate", "----------End----------");
            return result;
        }
        [HttpPost("GenerateDataSharingReport")]
        public Task<List<dynamic>> GenerateDataSharingReport([FromBody] DataSharingReportFields dataSharingReportFields)
        {
            return _reports.GenerateDataSharingReport(dataSharingReportFields);
        }

    }
}
