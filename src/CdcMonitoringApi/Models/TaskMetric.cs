namespace CdcMonitoringApi.Models;

public record TaskMetric(
    int Id, int TaskId, double LagSeconds, int RowsPerSecond , DateTime  Timestamp
    );