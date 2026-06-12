namespace CdcMonitoringApi.Models.Dtos;

public record TaskMetricDto(
    int Id,
    int TaskId,
    double LagSeconds,
    int RowsPerSecond,
    DateTime Timestamp
)
{
    public static TaskMetricDto FromEntity(TaskMetric metric) =>
        new(
            metric.Id,
            metric.TaskId,
            metric.LagSeconds,
            metric.RowsPerSecond,
            metric.Timestamp
        );
}
