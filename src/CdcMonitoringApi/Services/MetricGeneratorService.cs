namespace CdcMonitoringApi.Services;

public class MetricGeneratorService : BackgroundService
{

    private readonly ILogger<MetricGeneratorService> _logger;

    public MetricGeneratorService(ILogger<MetricGeneratorService> logger)
    {
        _logger = logger;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Tick at {Time}", DateTime.UtcNow);
            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }
    }
}