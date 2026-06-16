namespace CdcMonitoringApi.Models.Dtos;

public record MetricsSummaryDto(
    int TaskId,
    int WindowMinutes,
    int SampleCount,
    double AverageLagSeconds,
    double MaxLagSeconds,
    double AverageRowsPerSecond
);