using CdcMonitoringApi.Models;

namespace CdcMonitoringApi.IRepositories;

public interface IMetricRepository
{
    Task<IEnumerable<TaskMetric>> GetByTaskIdAsync(int taskId);
}