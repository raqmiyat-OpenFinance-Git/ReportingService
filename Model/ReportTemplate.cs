using Microsoft.AspNetCore.Mvc;
using ReportingService.Model;
using ReportingService.IServices;
using ReportingService.Service;
namespace ReportingService.Model
{
    public class ReportTemplate
    {
        public string? Value { get; set; }
        public string? DisplayName { get; set; }
        public string? FieldType { get; set; }
    }
}
