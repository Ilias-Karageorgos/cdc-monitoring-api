using CdcMonitoringApi.Models.Dtos;

namespace CdcMonitoringApi.IRepositories;

public interface IErrorRepository
{
        Task<TaskErrorSummaryDto?> GetSummaryAsync(int taskId, int windowMinutes);
}