using CdcMonitoringApi.Models;

namespace CdcMonitoringApi.Data;

public class InMemoryTaskStore
{
    private readonly List<ReplicationTask> _tasks = new List<ReplicationTask>{
            new ReplicationTask
            {
                Id = 1,
                Name = "Task 1",
                SourceDb = "Oracle",
                TargetDb = "Kafka",
                Status = ReplicationStatus.Running,
                LastUpdateTime = DateTime.UtcNow.AddMinutes(-5)
            },
            new ReplicationTask
            {
                Id = 2,
                Name = "Task 2",
                SourceDb = "SQL Server",
                TargetDb = "Kafka",
                Status = ReplicationStatus.Stopped,
                LastUpdateTime = DateTime.UtcNow.AddMinutes(-10)
            },
            new ReplicationTask
            {
                Id = 3,
                Name = "Task 3",
                SourceDb = "MySQL",
                TargetDb = "Kafka",
                Status = ReplicationStatus.Error,
                LastUpdateTime = DateTime.UtcNow.AddMinutes(-15)
            }
        };

    private readonly List<TaskMetric> _metrics = new List<TaskMetric>{
            new TaskMetric
            {
                Id = 1,
                TaskId = 1,
                LagSeconds = 0.5,
                RowsPerSecond = 1200,
                Timestamp = DateTime.UtcNow.AddMinutes(-3)
            },
            new TaskMetric
            {
                Id = 2,
                TaskId = 1,
                LagSeconds = 0.7,
                RowsPerSecond = 1100,
                Timestamp = DateTime.UtcNow.AddMinutes(-2)
            },
            new TaskMetric
            {
                Id = 3,
                TaskId = 1,
                LagSeconds = 0.6,
                RowsPerSecond = 1300,
                Timestamp = DateTime.UtcNow.AddMinutes(-1)
            },
            new TaskMetric
            {
                Id = 4,
                TaskId = 2,
                LagSeconds = 5.2,
                RowsPerSecond = 0,
                Timestamp = DateTime.UtcNow.AddMinutes(-2)
            },
            new TaskMetric
            {
                Id = 5,
                TaskId = 2,
                LagSeconds = 5.8,
                RowsPerSecond = 0,
                Timestamp = DateTime.UtcNow.AddMinutes(-1)
            }
        };

    public IEnumerable<ReplicationTask> GetAll()
    {
        return _tasks;
    }

    public ReplicationTask? GetById(int id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    public IEnumerable<TaskMetric> GetMetricsByTaskId(int taskId){
        return _metrics.Where(m => m.TaskId == taskId);
    }

}



