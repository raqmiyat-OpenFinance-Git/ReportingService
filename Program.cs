using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using ReportingService.Custom;
using ReportingService.IServices;
using ReportingService.Model;
using ReportingService.Service;
using ReportingService.Services;

NLogManagerService _logger = new NLogManagerService();
var builder = WebApplication.CreateBuilder(args);
var _dataBaseConnectionParams = builder.Configuration.GetSection(nameof(DataBaseConnectionParams)).Get<DataBaseConnectionParams>();
string Constr = SqlConManager.GetConnectionString(_dataBaseConnectionParams!.DBConnection!, _dataBaseConnectionParams.IsEncrypted);
builder.Services.Configure<StoredProcedureParams>(builder.Configuration.GetSection("StoredProcedureParams"));
builder.Services.Configure<DataBaseConnectionParams>(builder.Configuration.GetSection("DataBaseConnectionParams"));
builder.Services.Configure<ServiceParams>(builder.Configuration.GetSection("ServiceParams"));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ConsentDbConnection>(provider =>
{
    var config = provider.GetRequiredService<IOptions<DataBaseConnectionParams>>().Value;
    var connStr = SqlConManager.GetConnectionString(config.DBConnection!, config.IsEncrypted);
    return new ConsentDbConnection(connStr);
});

builder.Services.AddSingleton<DataSharingDBConnection>(provider =>
{
    var config = provider.GetRequiredService<IOptions<DataBaseConnectionParams>>().Value;
    var connStr = SqlConManager.GetConnectionString(config.DataSharingDBConnection!, config.IsEncrypted);
    return new DataSharingDBConnection(connStr);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.Configure<ServiceParams>(builder.Configuration.GetSection("ServiceParams"));
builder.Services.AddSingleton<NLogManagerService>();
builder.Services.AddSingleton<NLogReportService>();
builder.Services.AddTransient<ConnectCustom>();
builder.Services.AddTransient<IReportsService, ReportsService>();
builder.Services.AddTransient<IDataSharingReportService, DataSharingReportService>();
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapHealthChecks("/health", new HealthCheckOptions()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
