namespace ReportingService.Model
{
    public class DataBaseConnectionParams
    {
        public string? DBConnection { get; set; }
        public string? DataSharingDBConnection { get; set; }
        public string? ServiceIntiationDBConnection { get; set; }
        public bool IsEncrypted { get; set; }
        public int? CommandTimeout { get; set; }
    }
}
