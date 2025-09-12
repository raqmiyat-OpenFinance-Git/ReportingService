
using ReportingService.Model;

namespace ReportingService.IServices
{
    public interface IDataSharingReportService
    {
        int DataSharingReportDeleteTemplate(int deleteId, string Module);
        Task<List<dynamic>> GenerateDataSharingReport(DataSharingReportFields dataSharingReportFields);
        Task<List<DataSharingColumnInfo>> GetDataSharingReportColumnNames(string module,string templateName);
        DataSharingReport GetDataSharingReportTemplateData(int templateId, string module);
        Task<List<DataSharingTemplateList>> GetDataSharingReportTemplateList(string module);
        Task<List<DataSharingReportTemplate>> GetDataSharingReportTemplates();
        string SaveDataSharingReportTemplate(DataSharingReport dataSharingReport);
    }

}
