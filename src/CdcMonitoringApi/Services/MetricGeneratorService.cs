using CdcMonitoringApi.Data;
using CdcMonitoringApi.Models;

namespace CdcMonitoringApi.Services;

public class MetricGeneratorService : BackgroundService
{

    private readonly ILogger<MetricGeneratorService> _logger;
    private readonly IServiceScopeFactory _scopeFactory;


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
            await dbContext.SaveChangesAsync(stoppingToken);

            _logger.LogInformation(
                "Inserted metric for task {TaskId}: lag={LagSeconds}s, rows/s={RowsPerSecond}",
                metric.TaskId, metric.LagSeconds, metric.RowsPerSecond);

            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);

        }
    }
}