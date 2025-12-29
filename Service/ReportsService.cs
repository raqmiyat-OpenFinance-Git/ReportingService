using Dapper;
using Microsoft.Extensions.Options;
using ReportingService.IServices;
using ReportingService.Model;
using ReportingService.Services;
using System.Data;

namespace ReportingService.Service
{
    public class ReportsService : IReportsService
    {
        private readonly IDbConnection _idbConnection;
        private readonly NLogReportService _logger;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public ReportsService(ConsentDbConnection idbConnection, NLogReportService logger, IOptions<StoredProcedureParams> storedProcedureParams)
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
                    _storedProcedureParams.Value.consentSPParams!.ReportTemplatesList!,
                    commandType: CommandType.StoredProcedure)).ToList();
                return reportTemplates;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
            return reportTemplates;
        }

        public async Task<List<ColumnInfo>> GetColumnNames(string Module)
        {
            List<ColumnInfo> columnInfos = new List<ColumnInfo>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Module", Module);

                columnInfos = (await _idbConnection.QueryAsync<ColumnInfo>(
                    _storedProcedureParams.Value.consentSPParams!.ColumnInfo!,
                    parameters,
                    commandType: CommandType.StoredProcedure)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
            return columnInfos;
        }
        public async Task<List<TemplateList>> GetTemplateList(string Module)
        {
            List<TemplateList> templateList = new List<TemplateList>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Module", Module);

                templateList = (await _idbConnection.QueryAsync<TemplateList>(
                    _storedProcedureParams.Value.consentSPParams!.TemplateList!,
                    parameters,
                    commandType: CommandType.StoredProcedure)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
            return templateList;
        }
        public ConsentEventReport GetTemplateData(int templateId, string Module)
        {
            _logger.LogInfo("Reports", "GetTemplateData", "----------Start----------");

            ConsentEventReport ConsentEvent_report = new ConsentEventReport();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TemplateId", templateId, DbType.Int32);
                parameters.Add("@Module", Module, DbType.String);

                //if (Module == "Consent")
                //{
                    ConsentEvent_report.ConsentReportField =
                        _idbConnection.Query<ConsentReportFields>(
                            _storedProcedureParams.Value.consentSPParams!.GET_Template_Details!,
                            parameters,
                            commandType: CommandType.StoredProcedure).FirstOrDefault();
                //}
                //else if (Module == "DataSharing")
                //{
                //    ConsentEvent_report.ConsentReportField =
                //        _idbConnection.Query<ConsentReportFields>(
                //            _storedProcedureParams.Value.consentSPParams!.GET_Template_Details!,
                //            parameters,
                //            commandType: CommandType.StoredProcedure).FirstOrDefault();
                //}
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                throw;
            }

            _logger.LogInfo("Reports", "GetTemplateData", "----------End----------");
            return ConsentEvent_report;
        }

        public int DeleteTemplate(int deleteId, string Module)
        {
            _logger.LogInfo("Reports", "DeleteTemplate", "----------Start----------");

            int outputDesc = 1;

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DeleteId", deleteId, DbType.Int32);
                parameters.Add("@OutputStatus", dbType: DbType.Int32, direction: ParameterDirection.Output);

                //if (Module == "Consent")
                //{
                    _idbConnection.Query<int>(
                        _storedProcedureParams.Value.consentSPParams!.DeleteTemplate_Consent!,
                        parameters,
                        commandType: CommandType.StoredProcedure);
                //}
                //else if (Module == "Service Initiation")
                //{
                //    _idbConnection.Query<int>(
                //        _storedProcedureParams.Value.consentSPParams!.DeleteTemplate_Consent!,
                //        parameters,
                //        commandType: CommandType.StoredProcedure);
                //}
                //else if (Module == "Data Sharing")
                //{
                //    _idbConnection.Query<int>(
                //        _storedProcedureParams.Value.consentSPParams!.DeleteTemplate_Consent!,
                //        parameters,
                //        commandType: CommandType.StoredProcedure);
                //}

                outputDesc = parameters.Get<int>("@OutputStatus");
            }
            catch (Exception ex)
            {
                _logger.LogInfo(ex.Message);
            }

            _logger.LogInfo("Reports", "DeleteTemplate", "----------End----------");

            return outputDesc;
        }
        public string SaveReportTemplate(ConsentEventReport ConsentEventReport)
        {
            _logger.LogInfo("Reports", "SaveReportTemplate", "----------Start----------");
            string returnValue = "";

            //if (ConsentEventReport.ConsentType == "Consent")
            //{
                try
                {
                    //using IDbConnection db = new SqlConnection(ConfigManager.getDBConnection());
                    var parameters = new DynamicParameters();
                    parameters.Add("FromDate", ConsentEventReport.ConsentReportField!.FromDate, dbType: DbType.DateTime);
                    parameters.Add("ToDate", ConsentEventReport.ConsentReportField!.Todate, dbType: DbType.DateTime);
                    parameters.Add("Columndetails", ConsentEventReport.ConsentReportField!.Columndetails, dbType: DbType.String);
                    parameters.Add("TemplateName", ConsentEventReport.ConsentReportField!.TemplateName, dbType: DbType.String);
                    parameters.Add("ReportName", ConsentEventReport.ConsentReportField!.ReportName, dbType: DbType.String);
                    parameters.Add("CorrelationId", ConsentEventReport.ConsentReportField!.CorrelationId, dbType: DbType.String);
                    parameters.Add("Id", ConsentEventReport.ConsentReportField!.Id, dbType: DbType.String);
                    parameters.Add("ConsentGroupId", ConsentEventReport.ConsentReportField!.ConsentGroupId, dbType: DbType.String);
                    parameters.Add("RequestUrl", ConsentEventReport.ConsentReportField!.RequestUrl, dbType: DbType.String);
                    parameters.Add("ConsentType", ConsentEventReport.ConsentType, dbType: DbType.String);
                    parameters.Add("RequestType", ConsentEventReport.ConsentReportField!.RequestType, dbType: DbType.String);
                    parameters.Add("ConsentId", ConsentEventReport.ConsentReportField!.ConsentId, dbType: DbType.String);
                    parameters.Add("BaseConsentId", ConsentEventReport.ConsentReportField!.BaseConsentId, dbType: DbType.String);
                    parameters.Add("CurrentStatus", ConsentEventReport.ConsentReportField!.CurrentStatus, dbType: DbType.String);
                    parameters.Add("Status", ConsentEventReport.ConsentReportField!.Status, dbType: DbType.String);
                    parameters.Add("ExpirationDateTime", ConsentEventReport.ConsentReportField!.ExpirationDateTime, dbType: DbType.DateTime);
                    parameters.Add("AuthorizationChannel", ConsentEventReport.ConsentReportField!.AuthorizationChannel, dbType: DbType.String);
                    parameters.Add("InteractionId", ConsentEventReport.ConsentReportField!.InteractionId, dbType: DbType.String);
                    parameters.Add("UpdatedAt", ConsentEventReport.ConsentReportField!.UpdatedAt, dbType: DbType.DateTime);
                    parameters.Add("CreationDateTime", ConsentEventReport.ConsentReportField!.CreationDateTime, dbType: DbType.DateTime);
                    parameters.Add("LastUpdatedDateTime", ConsentEventReport.ConsentReportField!.LastUpdatedDateTime, dbType: DbType.DateTime);
                    parameters.Add("AccountType", ConsentEventReport.ConsentReportField!.AccountType, dbType: DbType.String);
                    parameters.Add("AccountSubType", ConsentEventReport.ConsentReportField!.AccountSubType, dbType: DbType.String);
                    parameters.Add("Permissions", ConsentEventReport.ConsentReportField!.Permissions, dbType: DbType.String);
                    parameters.Add("TppClientId", ConsentEventReport.ConsentReportField!.TppClientId, dbType: DbType.String);
                    parameters.Add("TppTppId", ConsentEventReport.ConsentReportField!.TppId, dbType: DbType.String);
                    parameters.Add("TppTppName", ConsentEventReport.ConsentReportField!.TppName, dbType: DbType.String);
                    parameters.Add("SoftwareStatementId", ConsentEventReport.ConsentReportField!.SoftwareStatementId, dbType: DbType.String);
                    parameters.Add("DirectoryRecord", ConsentEventReport.ConsentReportField!.DirectoryRecord, dbType: DbType.String);
                    parameters.Add("DecodedSsa", ConsentEventReport.ConsentReportField!.DecodedSsa, dbType: DbType.String);
                    parameters.Add("OrgId", ConsentEventReport.ConsentReportField!.OrgId, dbType: DbType.String);
                    parameters.Add("ParId", ConsentEventReport.ConsentReportField!.ParId, dbType: DbType.String);
                    parameters.Add("RarType", ConsentEventReport.ConsentReportField!.RarType, dbType: DbType.String);
                    parameters.Add("StandardVersion", ConsentEventReport.ConsentReportField!.StandardVersion, dbType: DbType.String);
                    parameters.Add("PsuIdentifiersUserId", ConsentEventReport.ConsentReportField!.PsuIdentifiersUserId, dbType: DbType.String);
                    parameters.Add("AccountIds", ConsentEventReport.ConsentReportField!.AccountIds, dbType: DbType.String);
                    parameters.Add("ConsentBody", ConsentEventReport.ConsentReportField!.ConsentBody, dbType: DbType.String);
                    parameters.Add("OzoneSupplementaryInformation", ConsentEventReport.ConsentReportField!.OzoneSupplementaryInformation, dbType: DbType.String);
                    parameters.Add("SupplementaryInformation", ConsentEventReport.ConsentReportField!.SupplementaryInformation, dbType: DbType.String);
                    parameters.Add("PaymentContext", ConsentEventReport.ConsentReportField!.PaymentContext, dbType: DbType.String);
                    parameters.Add("ConnectToken", ConsentEventReport.ConsentReportField!.ConnectToken, dbType: DbType.String);
                    parameters.Add("PaymentCategory", ConsentEventReport.ConsentReportField!.PaymentCategory, dbType: DbType.String);
                    parameters.Add("PaymentType", ConsentEventReport.ConsentReportField!.PaymentType, dbType: DbType.String);
                    parameters.Add("Output_Desc", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                        _idbConnection.Execute(
                   _storedProcedureParams.Value.consentSPParams!.SaveTemplate_Consent!,
                   parameters,
                   commandType: CommandType.StoredProcedure);
                    returnValue = parameters.Get<string>("Output_Desc");
                }
                catch (Exception ex)
                {
                    _logger.LogInfo(ex.Message);
                    return returnValue;
                }

            //}
            
            return returnValue;
        }
        public async Task<List<dynamic>> GenerateOriginatorReport(ConsentReportFields consentReportFields)
        {

            List<dynamic> ConsentReport = new List<dynamic>();
            try
            {
                
                    var parameters = new DynamicParameters();
                    
                    parameters.Add("FromDate", consentReportFields.FromDate, dbType: DbType.DateTime);
                    parameters.Add("ToDate", consentReportFields.Todate, dbType: DbType.DateTime);
                    parameters.Add("Columndetails", consentReportFields.Columndetails, dbType: DbType.String);
                    parameters.Add("TemplateName", consentReportFields.TemplateName, dbType: DbType.String);
                    parameters.Add("ReportName", consentReportFields.ReportName, dbType: DbType.String);
                    parameters.Add("CorrelationId", consentReportFields.CorrelationId, dbType: DbType.String);
                    parameters.Add("Id", consentReportFields.Id, dbType: DbType.String);
                    parameters.Add("ConsentGroupId", consentReportFields.ConsentGroupId, dbType: DbType.String);
                    parameters.Add("RequestUrl", consentReportFields.RequestUrl, dbType: DbType.String);
                    parameters.Add("ConsentType", consentReportFields.ConsentType, dbType: DbType.String);
                    parameters.Add("RequestType", consentReportFields.RequestType, dbType: DbType.String);
                    parameters.Add("ConsentId", consentReportFields.ConsentId, dbType: DbType.String);
                    parameters.Add("BaseConsentId", consentReportFields.BaseConsentId, dbType: DbType.String);
                    parameters.Add("CurrentStatus", consentReportFields.CurrentStatus, dbType: DbType.String);
                    parameters.Add("Status", consentReportFields.Status, dbType: DbType.String);
                    parameters.Add("ExpirationDateTime", consentReportFields.ExpirationDateTime, dbType: DbType.DateTime);
                    parameters.Add("AuthorizationChannel", consentReportFields.AuthorizationChannel, dbType: DbType.String);
                    parameters.Add("InteractionId", consentReportFields.InteractionId, dbType: DbType.String);
                    parameters.Add("UpdatedAt", consentReportFields.UpdatedAt, dbType: DbType.DateTime);
                    parameters.Add("CreationDateTime", consentReportFields.CreationDateTime, dbType: DbType.DateTime);
                    parameters.Add("LastUpdatedDateTime", consentReportFields.LastUpdatedDateTime, dbType: DbType.DateTime);
                    parameters.Add("AccountType", consentReportFields.AccountType, dbType: DbType.String);
                    parameters.Add("AccountSubType", consentReportFields.AccountSubType, dbType: DbType.String);
                    parameters.Add("Permissions", consentReportFields.Permissions, dbType: DbType.String);
                    parameters.Add("TppClientId", consentReportFields.TppClientId, dbType: DbType.String);
                    parameters.Add("TppTppId", consentReportFields.TppId, dbType: DbType.String);
                    parameters.Add("TppTppName", consentReportFields.TppName, dbType: DbType.String);
                    parameters.Add("SoftwareStatementId", consentReportFields.SoftwareStatementId, dbType: DbType.String);
                    parameters.Add("DirectoryRecord", consentReportFields.DirectoryRecord, dbType: DbType.String);
                    parameters.Add("DecodedSsa", consentReportFields.DecodedSsa, dbType: DbType.String);
                    parameters.Add("OrgId", consentReportFields.OrgId, dbType: DbType.String);
                    parameters.Add("ParId", consentReportFields.ParId, dbType: DbType.String);
                    parameters.Add("RarType", consentReportFields.RarType, dbType: DbType.String);
                    parameters.Add("StandardVersion", consentReportFields.StandardVersion, dbType: DbType.String);
                    parameters.Add("PsuIdentifiersUserId", consentReportFields.PsuIdentifiersUserId, dbType: DbType.String);
                    parameters.Add("AccountIds", consentReportFields.AccountIds, dbType: DbType.String);
                    parameters.Add("ConsentBody", consentReportFields.ConsentBody, dbType: DbType.String);
                    parameters.Add("OzoneSupplementaryInformation", consentReportFields.OzoneSupplementaryInformation, dbType: DbType.String);
                    parameters.Add("SupplementaryInformation", consentReportFields.SupplementaryInformation, dbType: DbType.String);
                    parameters.Add("PaymentContext", consentReportFields.PaymentContext, dbType: DbType.String);
                    parameters.Add("ConnectToken", consentReportFields.ConnectToken, dbType: DbType.String);
                    parameters.Add("PaymentCategory", consentReportFields.PaymentCategory, dbType: DbType.String);
                    parameters.Add("PaymentType", consentReportFields.PaymentType, dbType: DbType.String);

                return (await _idbConnection.QueryAsync<dynamic>(
            _storedProcedureParams.Value.consentSPParams!.GET_Consent_Report!,
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

