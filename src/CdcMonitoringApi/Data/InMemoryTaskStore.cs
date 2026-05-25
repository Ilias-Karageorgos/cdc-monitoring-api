using CdcMonitoringApi.Models;

namespace CdcMonitoringApi.Data;

public class InMemoryTaskStore
{
    private readonly List<ReplicationTask> _tasks = new List<ReplicationTask>{
            new ReplicationTask(1, "Task 1", "Oracle", "Kafka", ReplicationStatus.Running, DateTime.UtcNow.AddMinutes(-5)),
            new ReplicationTask(2, "Task 2", "SQL Server", "Kafka", ReplicationStatus.Stopped, DateTime.UtcNow.AddMinutes(-10)),
            new ReplicationTask(3, "Task 3", "MySQL", "Kafka", ReplicationStatus.Error, DateTime.UtcNow.AddMinutes(-15))
        };

    private readonly List<TaskMetric> _metrics = new List<TaskMetric>{
            new TaskMetric(1, 1, 0.5, 1200, DateTime.UtcNow.AddMinutes(-3)),
            new TaskMetric(2, 1, 0.7, 1100, DateTime.UtcNow.AddMinutes(-2)),
            new TaskMetric(3, 1, 0.6, 1300, DateTime.UtcNow.AddMinutes(-1)),
            new TaskMetric(4, 2, 5.2, 0,    DateTime.UtcNow.AddMinutes(-2)),
            new TaskMetric(5, 2, 5.8, 0,    DateTime.UtcNow.AddMinutes(-1))
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



