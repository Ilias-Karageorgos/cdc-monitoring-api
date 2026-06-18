namespace CdcMonitoringApi.Models.Dtos;

public record TaskErrorSummaryDto(
    int TaskId,
    int WindowMinutes,
    int TotalErrors,
    int CountByWarning,
    int CountByError,
    int CountByCritical,
    double ErrorRate
);