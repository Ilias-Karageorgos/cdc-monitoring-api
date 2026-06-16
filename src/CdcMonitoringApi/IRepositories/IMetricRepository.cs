using CdcMonitoringApi.Models;
using CdcMonitoringApi.Models.Dtos;

namespace CdcMonitoringApi.IRepositories;

public interface IMetricRepository
{
    Task<IEnumerable<TaskMetric>> GetByTaskIdAsync(int taskId);

    Task<MetricsSummaryDto?> GetSummaryAsync(int taskId, int windowMinutes);

}