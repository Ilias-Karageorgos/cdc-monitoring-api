using CdcMonitoringApi.Models;

namespace CdcMonitoringApi.IRepositories;

public interface ITaskRepository
{
    Task<IEnumerable<ReplicationTask>> GetAllAsync();
    Task<ReplicationTask?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int id);
    
}