using CdcMonitoringApi.IRepositories;
using CdcMonitoringApi.Data;
using CdcMonitoringApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CdcMonitoringApi.Repositories;

public class MetricRepository : IMetricRepository
{
    private readonly ApplicationDbContext _context;

    public MetricRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TaskMetric>> GetByTaskIdAsync(int taskId)
    {
        return await _context.TaskMetrics
            .Where(m => m.TaskId == taskId)
            .ToListAsync();
    }
}
