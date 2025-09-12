using System.Data;

namespace ReportingService.Model
{
    public interface IConsentDbConnection : IDisposable
    {
        IDbConnection Connection { get; }
    }

    public interface IDataSharingDbConnection : IDisposable
    {
        IDbConnection Connection { get; }
    }

}
