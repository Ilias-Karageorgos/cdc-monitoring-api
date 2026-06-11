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
        
        #region ReplicationTask
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
        #endregion


        #region TaskMetric                   
        modelBuilder.Entity<TaskMetric>().HasData(
            new TaskMetric
            {
                Id = 1,
                TaskId = 1,
                LagSeconds = 0.5,
                RowsPerSecond = 1200,
                Timestamp = new DateTime(2026, 6, 11, 13, 57, 0, DateTimeKind.Utc)
            },
            new TaskMetric
            {
                Id = 2,
                TaskId = 1,
                LagSeconds = 0.7,
                RowsPerSecond = 1100,
                Timestamp = new DateTime(2026, 6, 11, 13, 58, 0, DateTimeKind.Utc)
            },
            new TaskMetric
            {
                Id = 3,
                TaskId = 1,
                LagSeconds = 0.6,
                RowsPerSecond = 1300,
                Timestamp = new DateTime(2026, 6, 11, 13, 59, 0, DateTimeKind.Utc)
            },
            new TaskMetric
            {
                Id = 4,
                TaskId = 2,
                LagSeconds = 5.2,
                RowsPerSecond = 0,
                Timestamp = new DateTime(2026, 6, 11, 12, 58, 0, DateTimeKind.Utc)
            },
            new TaskMetric
            {
                Id = 5,
                TaskId = 2,
                LagSeconds = 5.8,
                RowsPerSecond = 0,
                Timestamp = new DateTime(2026, 6, 11, 12, 59, 0, DateTimeKind.Utc)
            }
        );
        #endregion
    }
}
