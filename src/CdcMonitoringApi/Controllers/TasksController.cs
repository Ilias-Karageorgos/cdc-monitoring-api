using Microsoft.AspNetCore.Mvc;
using CdcMonitoringApi.Models;
using CdcMonitoringApi.Data;


namespace CdcMonitoringApi.Controllers;

[ApiController]
[Route("tasks")]
public class TasksController : ControllerBase
{
    private readonly InMemoryTaskStore _store;

    public TasksController(InMemoryTaskStore store)
    {
        _store = store;
    }

    
    [HttpGet]
    public IEnumerable<ReplicationTask> GetTasks()
    {
        return _store.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<ReplicationTask> GetTaskById(int id)
    {
        var task = _store.GetById(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpGet("{id}/metrics")]
    public ActionResult<IEnumerable<TaskMetric>> GetTaskMetrics(int id)
    {
        var task = _store.GetById(id);
        if (task == null)
        {
            return NotFound();
        }
        var metrics = _store.GetMetricsByTaskId(id);
        return Ok(metrics);
    }
}