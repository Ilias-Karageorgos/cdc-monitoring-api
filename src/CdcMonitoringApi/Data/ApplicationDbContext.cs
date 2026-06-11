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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ReplicationTask>().HasData(
            new ReplicationTask
            {
                Id = 1,
                Name = "Oracle to Kafka",
                SourceDb = "Oracle",
                TargetDb = "Kafka",
                Status = ReplicationStatus.Running,
                LastUpdateTime = new DateTime(2026, 6, 11, 14, 0, 0, DateTimeKind.Utc)
            },
            new ReplicationTask
            {
                Id = 2,
                Name = "SQL Server to Kafka",
                SourceDb = "SQL Server",
                TargetDb = "Kafka",
                Status = ReplicationStatus.Stopped,
                LastUpdateTime = new DateTime(2026, 6, 11, 13, 0, 0, DateTimeKind.Utc)
            },
            new ReplicationTask
            {
                Id = 3,
                Name = "MySQL to Kafka",
                SourceDb = "MySQL",
                TargetDb = "Kafka",
                Status = ReplicationStatus.Error,
                LastUpdateTime = new DateTime(2026, 6, 11, 12, 0, 0, DateTimeKind.Utc)
            }
        );
    }

}
