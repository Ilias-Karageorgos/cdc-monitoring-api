using CdcMonitoringApi.Data;
using CdcMonitoringApi.Models;

namespace CdcMonitoringApi.Services;

public class MetricGeneratorService : BackgroundService
{

    private readonly ILogger<MetricGeneratorService> _logger;
    private readonly IServiceScopeFactory _scopeFactory;
    private static readonly string[] ErrorMessages =
    {
        "Connection timeout to source database",
        "Schema drift detected on source table",
        "Failed to apply transaction batch",
        "Source log file rotated unexpectedly",
        "Target table missing expected column",
        "Replication lag exceeded threshold"
    };
    private static readonly ErrorSeverity[] Severities = Enum.GetValues<ErrorSeverity>();

    public MetricGeneratorService(ILogger<MetricGeneratorService> logger, IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _scopeFactory.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var metric = new TaskMetric
            {
                TaskId = Random.Shared.Next(1, 4),
                LagSeconds = Random.Shared.NextDouble() * 10,
                RowsPerSecond = Random.Shared.Next(0, 2000),
                Timestamp = DateTime.UtcNow
            };

            dbContext.TaskMetrics.Add(metric);

            TaskError? error = null;                          
            if (Random.Shared.NextDouble() < 0.1)
            {
                error = new TaskError
                {
                    TaskId = Random.Shared.Next(1, 4),
                    Message = ErrorMessages[Random.Shared.Next(ErrorMessages.Length)],
                    Severity = Severities[Random.Shared.Next(Severities.Length)],
                    Timestamp = DateTime.UtcNow
                };

                dbContext.TaskErrors.Add(error);
            }

            await dbContext.SaveChangesAsync(stoppingToken);

            _logger.LogInformation(
                "Inserted metric for task {TaskId}: lag={LagSeconds}s, rows/s={RowsPerSecond}",
                metric.TaskId, metric.LagSeconds, metric.RowsPerSecond);

            if (error != null)
            {
                _logger.LogWarning(
                    "Generated {Severity} error for task {TaskId}: {Message}",
                    error.Severity, error.TaskId, error.Message);
            }


            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }
    }
}