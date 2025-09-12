using Dapper;
using Microsoft.Extensions.Options;
using ReportingService.IServices;
using ReportingService.Model;
using ReportingService.Services;
using System.Data;

namespace ReportingService.Service
{
    public class DataSharingReportService : IDataSharingReportService
    {
        private readonly IDbConnection _idbConnection;
        private readonly IDataSharingDbConnection _dataSharingDb;
        private readonly NLogReportService _logger;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public DataSharingReportService(DataSharingDBConnection idbConnection, NLogReportService logger, IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection.GetConnection();
            _logger = logger;
            _storedProcedureParams = storedProcedureParams;
        }

        public int DataSharingReportDeleteTemplate(int deleteId, string Module)
        {
            _logger.LogInfo("Reports", "DeleteTemplate", "----------Start----------");

            int outputDesc = 1;

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DeleteId", deleteId, DbType.Int32);
                parameters.Add("@OutputStatus", dbType: DbType.Int32, direction: ParameterDirection.Output);
                if (Module == "Data Sharing")
                {
                    _idbConnection.Query<int>(
                        _storedProcedureParams.Value.dataSharingReportParams!.DataSharingReportDeleteTemplate!,
                        parameters,
                        commandType: CommandType.StoredProcedure);
                }

                outputDesc = parameters.Get<int>("@OutputStatus");
            }
            catch (Exception ex)
            {
                _logger.LogInfo(ex.Message);
            }

            _logger.LogInfo("Reports", "DeleteTemplate", "----------End----------");

            return outputDesc;
        }

        public async Task<List<dynamic>> GenerateDataSharingReport(DataSharingReportFields dataSharingReportFields)
        {
            List<dynamic> ConsentReport = new List<dynamic>();
            try
            {

                var parameters = new DynamicParameters();

                parameters.Add("FromDate", dataSharingReportFields.FromDate, dbType: DbType.DateTime);
                parameters.Add("ToDate", dataSharingReportFields.ToDate, dbType: DbType.DateTime);
                parameters.Add("Columndetails", dataSharingReportFields.Columndetails, dbType: DbType.String);
                parameters.Add("TemplateName", dataSharingReportFields.TemplateName, dbType: DbType.String);
                parameters.Add("ReportName", dataSharingReportFields.ReportName, dbType: DbType.String);
                parameters.Add("CorrelationId", dataSharingReportFields.CorrelationId, dbType: DbType.String);
                parameters.Add("AccountId", dataSharingReportFields.AccountId, dbType: DbType.String);
                parameters.Add("AccountType", dataSharingReportFields.AccountType, dbType: DbType.String);
                parameters.Add("AccountSubType", dataSharingReportFields.AccountSubType, dbType: DbType.String);
                parameters.Add("Type", dataSharingReportFields.Type, dbType: DbType.String);
                parameters.Add("Status", dataSharingReportFields.Status, dbType: DbType.String);

                return (await _idbConnection.QueryAsync<dynamic>(
            _storedProcedureParams.Value.dataSharingReportParams!.GenerateDataSharingReport!,
            parameters,
            commandType: CommandType.StoredProcedure)).ToList();

            }
            catch (Exception ex)
            {
                _logger.LogInfo(ex.Message);
            }
            return ConsentReport;
        }

        public async Task<List<DataSharingColumnInfo>> GetDataSharingReportColumnNames(string module,string templateName)
        {
            List<DataSharingColumnInfo> columnInfos = new List<DataSharingColumnInfo>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Module", module);
                parameters.Add("@TemplateName", templateName);

                columnInfos = (await _idbConnection.QueryAsync<DataSharingColumnInfo>(
                    _storedProcedureParams.Value.dataSharingReportParams!.GetDataSharingReportColumnNames!,
                    parameters,
                    commandType: CommandType.StoredProcedure)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
            return columnInfos;
        }

        public DataSharingReport GetDataSharingReportTemplateData(int templateId, string module)
        {
            _logger.LogInfo("Reports", "GetTemplateData", "----------Start----------");

            DataSharingReport ConsentEvent_report = new DataSharingReport();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TemplateId", templateId, DbType.Int32);
                parameters.Add("@Module", module, DbType.String);

                if (module == "DataSharing")
                {
                    ConsentEvent_report.dataSharingReportField =
                        _idbConnection.Query<DataSharingReportFields>(
                            _storedProcedureParams.Value.dataSharingReportParams!.GetDataSharingReportTemplateData!,
                            parameters,
                            commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                throw;
            }

            _logger.LogInfo("Reports", "GetTemplateData", "----------End----------");
            return ConsentEvent_report;
        }

        public async Task<List<DataSharingTemplateList>> GetDataSharingReportTemplateList(string module)
        {
            List<DataSharingTemplateList> templateList = new List<DataSharingTemplateList>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Module", module);

                templateList = (await _idbConnection.QueryAsync<DataSharingTemplateList>(
                    _storedProcedureParams.Value.dataSharingReportParams!.GetDataSharingReportTemplateList!,
                    parameters,
                    commandType: CommandType.StoredProcedure)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
            return templateList;
        }

        public async Task<List<DataSharingReportTemplate>> GetDataSharingReportTemplates()
        {
            List<DataSharingReportTemplate> reportTemplates = new List<DataSharingReportTemplate>();
            try
            {
                reportTemplates = (await _idbConnection.QueryAsync<DataSharingReportTemplate>(
                    _storedProcedureParams.Value.dataSharingReportParams!.GetDataSharingReportTemplates!,
                    commandType: CommandType.StoredProcedure)).ToList();
                return reportTemplates;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
            return reportTemplates;
        }

        public  string SaveDataSharingReportTemplate(DataSharingReport dataSharingReport)
        {
            _logger.LogInfo("Reports", "SaveReportTemplate", "----------Start----------");
            string returnValue = "";

            if (dataSharingReport.Module == "DataSharing")
            {
                try
                {
                    //using IDbConnection db = new SqlConnection(ConfigManager.getDBConnection());
                    var parameters = new DynamicParameters();
                    parameters.Add("FromDate", dataSharingReport.dataSharingReportField!.FromDate, DbType.DateTime);
                    parameters.Add("Todate", dataSharingReport.dataSharingReportField!.ToDate, DbType.DateTime);
                    parameters.Add("Columndetails", dataSharingReport.dataSharingReportField!.Columndetails, DbType.String);
                    parameters.Add("TemplateName", dataSharingReport.dataSharingReportField!.TemplateName, DbType.String);
                    parameters.Add("ReportName", dataSharingReport.dataSharingReportField!.ReportName, DbType.String);
                    parameters.Add("CorrelationId", dataSharingReport.dataSharingReportField!.CorrelationId, DbType.String);
                    parameters.Add("AccountId", dataSharingReport.dataSharingReportField.AccountId, dbType: DbType.String);
                    parameters.Add("AccountType", dataSharingReport.dataSharingReportField.AccountType, dbType: DbType.String);
                    parameters.Add("AccountSubType", dataSharingReport.dataSharingReportField.AccountSubType, dbType: DbType.String);
                    parameters.Add("Type", dataSharingReport.dataSharingReportField.Type, dbType: DbType.String);
                    parameters.Add("Status", dataSharingReport.dataSharingReportField.Status, dbType: DbType.String);
                    parameters.Add("Output_Desc", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    _idbConnection.Execute(
               _storedProcedureParams.Value.dataSharingReportParams!.SaveDataSharingReportTemplate!,
               parameters,
               commandType: CommandType.StoredProcedure);
                    returnValue = parameters.Get<string>("Output_Desc");
                }
                catch (Exception ex)
                {
                    _logger.LogInfo(ex.Message);
                    return returnValue;
                }

            }

            return returnValue;
        }
    }

}

