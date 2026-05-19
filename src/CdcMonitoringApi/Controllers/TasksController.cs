using Microsoft.AspNetCore.Mvc;
using CdcMonitoringApi.Models;

namespace CdcMonitoringApi.Controllers;

[ApiController]
[Route("tasks")]
public class TasksController : ControllerBase
{
    [HttpGet]
public List<ReplicationTask> GetTasks()
{
    return new List<ReplicationTask> {
        new ReplicationTask(1, "Task 1", "Oracle", "Kafka", ReplicationStatus.Running, DateTime.UtcNow.AddMinutes(-5)),
        new ReplicationTask(2, "Task 2", "SQL Server", "Kafka", ReplicationStatus.Stopped, DateTime.UtcNow.AddMinutes(-10)),
        new ReplicationTask(3, "Task 3", "MySQL", "Kafka", ReplicationStatus.Error, DateTime.UtcNow.AddMinutes(-15))
    };
}

};