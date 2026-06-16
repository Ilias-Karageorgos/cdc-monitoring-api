using CdcMonitoringApi.IRepositories;
using CdcMonitoringApi.Data;
using CdcMonitoringApi.Models;
using CdcMonitoringApi.Models.Dtos;
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

    public async Task<MetricsSummaryDto?> GetSummaryAsync(int taskId, int windowMinutes)
    {
        var since = DateTime.UtcNow.AddMinutes(-windowMinutes);

        var query = _context.TaskMetrics
            .Where(m => m.TaskId == taskId && m.Timestamp >= since);

        var count = await query.CountAsync();
        if (count == 0)
        {
            return null;
        }

        var averageLag = await query.AverageAsync(m => m.LagSeconds);
        var maxLag = await query.MaxAsync(m => m.LagSeconds);
        var averageThroughput = await query.AverageAsync(m => (double)m.RowsPerSecond);

        return new MetricsSummaryDto(
            TaskId: taskId,
            WindowMinutes: windowMinutes,
            SampleCount: count,
            AverageLagSeconds: averageLag,
            MaxLagSeconds: maxLag,
            AverageRowsPerSecond: averageThroughput
        );
    }
}
