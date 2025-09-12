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

                if (Module == "Consent")
                {
                    ConsentEvent_report.ConsentReportField =
                        _idbConnection.Query<ConsentReportFields>(
                            _storedProcedureParams.Value.consentSPParams!.GET_Template_Details!,
                            parameters,
                            commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
                else if (Module == "DataSharing")
                {
                    ConsentEvent_report.ConsentReportField =
                        _idbConnection.Query<ConsentReportFields>(
                            _storedProcedureParams.Value.consentSPParams!.GET_Template_Details!,
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

        public int DeleteTemplate(int deleteId, string Module)
        {
            _logger.LogInfo("Reports", "DeleteTemplate", "----------Start----------");

            int outputDesc = 1;

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DeleteId", deleteId, DbType.Int32);
                parameters.Add("@OutputStatus", dbType: DbType.Int32, direction: ParameterDirection.Output);

                if (Module == "Consent")
                {
                    _idbConnection.Query<int>(
                        _storedProcedureParams.Value.consentSPParams!.DeleteTemplate_Consent!,
                        parameters,
                        commandType: CommandType.StoredProcedure);
                }
                else if (Module == "Service Initiation")
                {
                    _idbConnection.Query<int>(
                        _storedProcedureParams.Value.consentSPParams!.DeleteTemplate_Consent!,
                        parameters,
                        commandType: CommandType.StoredProcedure);
                }
                else if (Module == "Data Sharing")
                {
                    _idbConnection.Query<int>(
                        _storedProcedureParams.Value.consentSPParams!.DeleteTemplate_Consent!,
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
        public string SaveReportTemplate(ConsentEventReport ConsentEventReport)
        {
            _logger.LogInfo("Reports", "SaveReportTemplate", "----------Start----------");
            string returnValue = "";

            if (ConsentEventReport.Module == "Consent")
            {
                try
                {
                    //using IDbConnection db = new SqlConnection(ConfigManager.getDBConnection());
                    var parameters = new DynamicParameters();
                    parameters.Add("FromDate", ConsentEventReport.ConsentReportField!.FromDate, DbType.DateTime);
                    parameters.Add("Todate", ConsentEventReport.ConsentReportField!.Todate, DbType.DateTime);
                    parameters.Add("Columndetails", ConsentEventReport.ConsentReportField!.Columndetails, DbType.String);
                    parameters.Add("TemplateName", ConsentEventReport.ConsentReportField!.TemplateName, DbType.String);
                    parameters.Add("ReportName", ConsentEventReport.ConsentReportField!.ReportName, DbType.String);
                    parameters.Add("CorrelationId", ConsentEventReport.ConsentReportField!.CorrelationId, DbType.String);
                    parameters.Add("RequestType", ConsentEventReport.ConsentReportField!.RequestType, DbType.String);
                    parameters.Add("BaseConsentId", ConsentEventReport.ConsentReportField!.BaseConsentId, DbType.String);
                    parameters.Add("ExpirationDateTime", ConsentEventReport.ConsentReportField!.ExpirationDateTime, DbType.DateTime);
                    parameters.Add("TransactionFromDateTime", ConsentEventReport.ConsentReportField!.TransactionFromDateTime, DbType.DateTime);
                    parameters.Add("TransactionToDateTime", ConsentEventReport.ConsentReportField!.TransactionToDateTime, DbType.DateTime);
                    parameters.Add("ConsentId", ConsentEventReport.ConsentReportField!.ConsentId, DbType.String);
                    parameters.Add("AccountType", ConsentEventReport.ConsentReportField!.AccountType, DbType.String);
                    parameters.Add("AccountSubType", ConsentEventReport.ConsentReportField!.AccountSubType, DbType.String);
                    parameters.Add("Permissions", ConsentEventReport.ConsentReportField!.Permissions, DbType.String);
                    parameters.Add("Purpose", ConsentEventReport.ConsentReportField!.Purpose, DbType.String);
                    parameters.Add("RevokedBy", ConsentEventReport.ConsentReportField!.RevokedBy, DbType.String);
                    parameters.Add("OnBehalfOf_TradingName", ConsentEventReport.ConsentReportField!.OnBehalfOf_TradingName, DbType.String);
                    parameters.Add("StatusFromConsentBody", ConsentEventReport.ConsentReportField!.StatusFromConsentBody, DbType.String);
                    parameters.Add("OnBehalfOf_LegalName", ConsentEventReport.ConsentReportField!.OnBehalfOf_LegalName, DbType.String);
                    parameters.Add("OnBehalfOf_IdentifierType", ConsentEventReport.ConsentReportField!.OnBehalfOf_IdentifierType, DbType.String);
                    parameters.Add("OnBehalfOf_Identifier", ConsentEventReport.ConsentReportField!.OnBehalfOf_Identifier, DbType.String);
                    parameters.Add("Billing_UserType", ConsentEventReport.ConsentReportField!.Billing_UserType, DbType.String);
                    parameters.Add("Billing_Purpose", ConsentEventReport.ConsentReportField!.Billing_Purpose, DbType.String);
                    parameters.Add("Billing_IsLargeCorporate", ConsentEventReport.ConsentReportField!.Billing_IsLargeCorporate, DbType.Boolean);
                    parameters.Add("TotalRequiredAuthorizations", ConsentEventReport.ConsentReportField!.TotalRequiredAuthorizations, DbType.Int64);
                    parameters.Add("AuthorizersJson", ConsentEventReport.ConsentReportField!.AuthorizersJson, DbType.String);
                    parameters.Add("Tpp_ClientId", ConsentEventReport.ConsentReportField!.Tpp_ClientId, DbType.String);
                    parameters.Add("Tpp_TppId", ConsentEventReport.ConsentReportField!.Tpp_TppId, DbType.String);
                    parameters.Add("Tpp_TppName", ConsentEventReport.ConsentReportField!.Tpp_TppName, DbType.String);
                    parameters.Add("Tpp_SoftwareStatementId", ConsentEventReport.ConsentReportField!.Tpp_SoftwareStatementId, DbType.String);
                    parameters.Add("Tpp_DirectoryRecord", ConsentEventReport.ConsentReportField!.Tpp_DirectoryRecord, DbType.String);
                    parameters.Add("Tpp_OrgId", ConsentEventReport.ConsentReportField!.Tpp_OrgId, DbType.String);
                    parameters.Add("Ssa_ClientName", ConsentEventReport.ConsentReportField!.Ssa_ClientName, DbType.String);
                    parameters.Add("Ssa_ClientUri", ConsentEventReport.ConsentReportField!.Ssa_ClientUri, DbType.String);
                    parameters.Add("Ssa_LogoUri", ConsentEventReport.ConsentReportField!.Ssa_LogoUri, DbType.String);
                    parameters.Add("Ssa_JwksUri", ConsentEventReport.ConsentReportField!.Ssa_JwksUri, DbType.String);
                    parameters.Add("Ssa_ClientId", ConsentEventReport.ConsentReportField!.Ssa_ClientId, DbType.String);
                    parameters.Add("Ssa_Roles", ConsentEventReport.ConsentReportField!.Ssa_Roles, DbType.String);
                    parameters.Add("Ssa_SectorIdentifierUri", ConsentEventReport.ConsentReportField!.Ssa_SectorIdentifierUri, DbType.String);
                    parameters.Add("Ssa_ApplicationType", ConsentEventReport.ConsentReportField!.Ssa_ApplicationType, DbType.String);
                    parameters.Add("Ssa_OrganisationId", ConsentEventReport.ConsentReportField!.Ssa_OrganisationId, DbType.String);
                    parameters.Add("Ssa_RedirectUris", ConsentEventReport.ConsentReportField!.Ssa_RedirectUris, DbType.String);
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

            }
            
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
                    parameters.Add("RequestType", consentReportFields.RequestType, dbType: DbType.String);
                    parameters.Add("BaseConsentId", consentReportFields.BaseConsentId, dbType: DbType.String);
                    parameters.Add("ExpirationDateTime", consentReportFields.ExpirationDateTime, dbType: DbType.DateTime);
                    parameters.Add("TransactionFromDateTime", consentReportFields.TransactionFromDateTime, dbType: DbType.DateTime);
                    parameters.Add("TransactionToDateTime", consentReportFields.TransactionToDateTime, dbType: DbType.DateTime);
                    parameters.Add("ConsentId", consentReportFields.ConsentId, dbType: DbType.String);
                    parameters.Add("AccountType", consentReportFields.AccountType, dbType: DbType.String);
                    parameters.Add("AccountSubType", consentReportFields.AccountSubType, dbType: DbType.String);
                    parameters.Add("Permissions", consentReportFields.Permissions, dbType: DbType.String);
                    parameters.Add("Purpose", consentReportFields.Purpose, dbType: DbType.String);
                    parameters.Add("StatusFromConsentBody", consentReportFields.StatusFromConsentBody, dbType: DbType.String);
                    parameters.Add("RevokedBy", consentReportFields.RevokedBy, dbType: DbType.String);
                    parameters.Add("OnBehalfOf_TradingName", consentReportFields.OnBehalfOf_TradingName, dbType: DbType.String);
                    parameters.Add("OnBehalfOf_LegalName", consentReportFields.OnBehalfOf_LegalName, dbType: DbType.String);
                    parameters.Add("OnBehalfOf_IdentifierType", consentReportFields.OnBehalfOf_IdentifierType, dbType: DbType.String);
                    parameters.Add("OnBehalfOf_Identifier", consentReportFields.OnBehalfOf_Identifier, dbType: DbType.String);
                    parameters.Add("Billing_UserType", consentReportFields.Billing_UserType, dbType: DbType.String);
                    parameters.Add("Billing_Purpose", consentReportFields.Billing_Purpose, dbType: DbType.String);
                    parameters.Add("Billing_IsLargeCorporate", consentReportFields.Billing_IsLargeCorporate, dbType: DbType.Boolean);
                    parameters.Add("TotalRequiredAuthorizations", consentReportFields.TotalRequiredAuthorizations, dbType: DbType.Int32);
                    parameters.Add("AuthorizersJson", consentReportFields.AuthorizersJson, dbType: DbType.String);
                    parameters.Add("Tpp_ClientId", consentReportFields.Tpp_ClientId, dbType: DbType.String);
                    parameters.Add("Tpp_TppId", consentReportFields.Tpp_TppId, dbType: DbType.String);
                    parameters.Add("Tpp_TppName", consentReportFields.Tpp_TppName, dbType: DbType.String);
                    parameters.Add("Tpp_SoftwareStatementId", consentReportFields.Tpp_SoftwareStatementId, dbType: DbType.String);
                    parameters.Add("Tpp_DirectoryRecord", consentReportFields.Tpp_DirectoryRecord, dbType: DbType.String);
                    parameters.Add("Tpp_OrgId", consentReportFields.Tpp_OrgId, dbType: DbType.String);
                    parameters.Add("Ssa_ClientName", consentReportFields.Ssa_ClientName, dbType: DbType.String);
                    parameters.Add("Ssa_ClientUri", consentReportFields.Ssa_ClientUri, dbType: DbType.String);
                    parameters.Add("Ssa_LogoUri", consentReportFields.Ssa_LogoUri, dbType: DbType.String);
                    parameters.Add("Ssa_JwksUri", consentReportFields.Ssa_JwksUri, dbType: DbType.String);
                    parameters.Add("Ssa_ClientId", consentReportFields.Ssa_ClientId, dbType: DbType.String);
                    parameters.Add("Ssa_Roles", consentReportFields.Ssa_Roles, dbType: DbType.String);
                    parameters.Add("Ssa_SectorIdentifierUri", consentReportFields.Ssa_SectorIdentifierUri, dbType: DbType.String);
                    parameters.Add("Ssa_ApplicationType", consentReportFields.Ssa_ApplicationType, dbType: DbType.String);
                    parameters.Add("Ssa_OrganisationId", consentReportFields.Ssa_OrganisationId, dbType: DbType.String);
                    parameters.Add("Ssa_RedirectUris", consentReportFields.Ssa_RedirectUris, dbType: DbType.String);

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

