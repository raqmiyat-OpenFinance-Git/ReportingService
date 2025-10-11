using Dapper;
using Microsoft.Extensions.Options;
using ReportingService.IServices;
using ReportingService.Model;
using ReportingService.Services;
using System.Data;

namespace ReportingService.Service
{
    public class ServiceInitiationReportService: IServiceInitiationReportService
    {
        private readonly IDbConnection _idbConnection;
        private readonly NLogReportService _logger;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public ServiceInitiationReportService(ServiceIntiationDbConnection idbConnection, NLogReportService logger, IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection.GetConnection();
            _logger = logger;
            _storedProcedureParams = storedProcedureParams;
        }
        public async Task<List<ReportTemplate>> GetReportTemplates()
        {
            List<ReportTemplate> reportTemplates = new List<ReportTemplate>();
            try
            {
                reportTemplates = (await _idbConnection.QueryAsync<ReportTemplate>(
                    _storedProcedureParams.Value.serviceInitiationReportParams!.ServiceInititaionTemplates!,
                    commandType: CommandType.StoredProcedure)).ToList();
                return reportTemplates;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
            return reportTemplates;
        }
        public async Task<List<ColumnInfo>> GetColumnNames()
        {
            List<ColumnInfo> columnInfos = new List<ColumnInfo>();
            try
            {
                columnInfos = (await _idbConnection.QueryAsync<ColumnInfo>(
                    _storedProcedureParams.Value.serviceInitiationReportParams!.ServiceInititaionColumnNames!,
                    commandType: CommandType.StoredProcedure)).ToList()!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
            return columnInfos;
        }
        public async Task<List<TemplateList>> GetTemplateList()
        {
            List<TemplateList> templateList = new List<TemplateList>();
            try
            {
                templateList = (await _idbConnection.QueryAsync<TemplateList>(
                    _storedProcedureParams.Value.serviceInitiationReportParams.ServiceInititaionTemplateList,
                    commandType: CommandType.StoredProcedure)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
            return templateList;
        }
        public ServiceInitiationReport GetTemplateData(int templateId)
        {
            _logger.LogInfo("Reports", "GetTemplateData", "----------Start----------");

            ServiceInitiationReport report = new ServiceInitiationReport();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TemplateId", templateId, DbType.Int32);


                report.serviceInitiationReportFields =
                        _idbConnection.Query<ServiceIntiationReportFields>(
                            _storedProcedureParams.Value.serviceInitiationReportParams!.ServiceInititaionTemplateData!,
                            parameters,
                            commandType: CommandType.StoredProcedure).FirstOrDefault();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                throw;
            }

            _logger.LogInfo("Reports", "GetTemplateData", "----------End----------");
            return report;
        }
        public int DeleteTemplate(int deleteId)
        {
            _logger.LogInfo("Reports", "DeleteTemplate", "----------Start----------");

            int outputDesc = 1;

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DeleteId", deleteId, DbType.Int32);
                parameters.Add("@OutputStatus", dbType: DbType.Int32, direction: ParameterDirection.Output);


                _idbConnection.Query<int>(
                    _storedProcedureParams.Value.serviceInitiationReportParams!.ServiceInititaiontDeleteTemplate!,
                    parameters,
                    commandType: CommandType.StoredProcedure);


                outputDesc = parameters.Get<int>("@OutputStatus");
            }
            catch (Exception ex)
            {
                _logger.LogInfo(ex.Message);
            }

            _logger.LogInfo("Reports", "DeleteTemplate", "----------End----------");

            return outputDesc;
        }
        public string SaveReportTemplate(ServiceInitiationReport serviceInitiationReport)
        {
            _logger.LogInfo("Reports", "SaveReportTemplate", "----------Start----------");
            string returnValue = "";


            try
            {
                //using IDbConnection db = new SqlConnection(ConfigManager.getDBConnection());
                var parameters = new DynamicParameters();
                parameters.Add("FromDate", serviceInitiationReport.serviceInitiationReportFields!.FromDate, DbType.DateTime);
                parameters.Add("Todate", serviceInitiationReport.serviceInitiationReportFields!.ToDate, DbType.DateTime);
                parameters.Add("Columndetails", serviceInitiationReport.serviceInitiationReportFields!.ColumnDetails, DbType.String);
                parameters.Add("TemplateName", serviceInitiationReport.serviceInitiationReportFields!.TemplateName, DbType.String);
                parameters.Add("ReportName", serviceInitiationReport.serviceInitiationReportFields!.ReportName, DbType.String);
                parameters.Add("CorrelationId", serviceInitiationReport.serviceInitiationReportFields!.ConsentId, DbType.String);
                parameters.Add("CorrelationId", serviceInitiationReport.serviceInitiationReportFields!.InstructionAmount, DbType.String);
                parameters.Add("CorrelationId", serviceInitiationReport.serviceInitiationReportFields!.InstructionCurrency, DbType.String);
                parameters.Add("CorrelationId", serviceInitiationReport.serviceInitiationReportFields!.PaymentTransactionId, DbType.String);
                parameters.Add("CorrelationId", serviceInitiationReport.serviceInitiationReportFields!.PaymentStatus, DbType.String);
                parameters.Add("CorrelationId", serviceInitiationReport.serviceInitiationReportFields!.TppName, DbType.String);
                parameters.Add("CorrelationId", serviceInitiationReport.serviceInitiationReportFields!.CreatedOn, DbType.DateTime);
                parameters.Add("CorrelationId", serviceInitiationReport.serviceInitiationReportFields!.CreatedBy, DbType.String);
                parameters.Add("CorrelationId", serviceInitiationReport.serviceInitiationReportFields!.ModifiedOn, DbType.DateTime);
                parameters.Add("CorrelationId", serviceInitiationReport.serviceInitiationReportFields!.ModifiedBy, DbType.String);
                parameters.Add("Output_Desc", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                _idbConnection.Execute(
           _storedProcedureParams.Value.serviceInitiationReportParams!.SaveServiceInititaionReportTemplate!,
           parameters,
           commandType: CommandType.StoredProcedure);
                returnValue = parameters.Get<string>("Output_Desc");
            }
            catch (Exception ex)
            {
                _logger.LogInfo(ex.Message);
                return returnValue;
            }


            return returnValue;
        }
        public async Task<List<dynamic>> GenerateServiceInitiationReport(ServiceIntiationReportFields serviceInitiationReport)
        {

            List<dynamic> ConsentReport = new List<dynamic>();
            try
            {

                var parameters = new DynamicParameters();

                parameters.Add("FromDate", serviceInitiationReport!.FromDate, DbType.DateTime);
                parameters.Add("Todate", serviceInitiationReport.ToDate, DbType.DateTime);
                parameters.Add("Columndetails", serviceInitiationReport.ColumnDetails, DbType.String);
                parameters.Add("TemplateName", serviceInitiationReport.TemplateName, DbType.String);
                parameters.Add("ReportName", serviceInitiationReport.ReportName, DbType.String);
                parameters.Add("CorrelationId", serviceInitiationReport.ConsentId, DbType.String);
                parameters.Add("CorrelationId", serviceInitiationReport.InstructionAmount, DbType.String);
                parameters.Add("CorrelationId", serviceInitiationReport.InstructionCurrency, DbType.String);
                parameters.Add("CorrelationId", serviceInitiationReport.PaymentTransactionId, DbType.String);
                parameters.Add("CorrelationId", serviceInitiationReport.PaymentStatus, DbType.String);
                parameters.Add("CorrelationId", serviceInitiationReport.TppName, DbType.String);
                parameters.Add("CorrelationId", serviceInitiationReport.CreatedOn, DbType.DateTime);
                parameters.Add("CorrelationId", serviceInitiationReport.CreatedBy, DbType.String);
                parameters.Add("CorrelationId", serviceInitiationReport.ModifiedOn, DbType.DateTime);
                parameters.Add("CorrelationId", serviceInitiationReport.ModifiedBy, DbType.String);
                parameters.Add("Output_Desc", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                return (await _idbConnection.QueryAsync<dynamic>(
            _storedProcedureParams.Value.serviceInitiationReportParams!.GenerateServiceInititaionReport!,
            parameters,
            commandType: CommandType.StoredProcedure)).ToList();

            }
            catch (Exception ex)
            {
                _logger.LogInfo(ex.Message);
            }
            return ConsentReport;
        }
    }
}
