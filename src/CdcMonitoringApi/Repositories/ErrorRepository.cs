using CdcMonitoringApi.Data;
using CdcMonitoringApi.IRepositories;
using CdcMonitoringApi.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using CdcMonitoringApi.Models;

namespace CdcMonitoringApi.Repositories;

public class ErrorRepository : IErrorRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ErrorRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TaskErrorSummaryDto?> GetSummaryAsync(int taskId, int sinceMinutes)
    {

        var since = DateTime.UtcNow.AddMinutes(-sinceMinutes);

        var query = _dbContext.TaskErrors
            .Where(m => m.TaskId == taskId && m.Timestamp >= since);


        var count = await query.CountAsync();
        if (count == 0)
        {
            return null;
        }

        var warningCount = await query.CountAsync(e => e.Severity == ErrorSeverity.Warning); ;
        var errorCount = await query.CountAsync(e => e.Severity == ErrorSeverity.Error); ;
        var criticalCount = await query.CountAsync(e => e.Severity == ErrorSeverity.Critical);
        double errorRatePerHour = (double)count * 60 / sinceMinutes;


        return new TaskErrorSummaryDto(
            TaskId: taskId,
            WindowMinutes: sinceMinutes,
            TotalErrors: count,
            CountByWarning: warningCount,
            CountByError: errorCount,
            CountByCritical: criticalCount,
            ErrorRate: errorRatePerHour
        );
    }

}

