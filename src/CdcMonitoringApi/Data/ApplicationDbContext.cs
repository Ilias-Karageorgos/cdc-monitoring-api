using Microsoft.EntityFrameworkCore;
using CdcMonitoringApi.Models;

namespace CdcMonitoringApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ReplicationTask> ReplicationTasks => Set<ReplicationTask>();
    public DbSet<TaskMetric> TaskMetrics => Set<TaskMetric>();
    public DbSet<TaskError> TaskErrors => Set<TaskError>();
}
