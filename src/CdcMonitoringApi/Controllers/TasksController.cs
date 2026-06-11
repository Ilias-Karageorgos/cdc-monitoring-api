using Microsoft.AspNetCore.Mvc;
using CdcMonitoringApi.Models;
using CdcMonitoringApi.IRepositories;


namespace CdcMonitoringApi.Controllers;

[ApiController]
[Route("tasks")]
public class TasksController : ControllerBase
{
    private readonly ITaskRepository _repo;

    public TasksController(ITaskRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReplicationTask>>> GetTasks()
    {
        var tasks = await _repo.GetAllAsync();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReplicationTask>> GetTaskById(int id)
    {
        var task = await _repo.GetByIdAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }


    // [HttpGet("{id}/metrics")]
    // public ActionResult<IEnumerable<TaskMetric>> GetTaskMetrics(int id)
    // {
    //     var task = _store.GetById(id);
    //     if (task == null)
    //     {
    //         return NotFound();
    //     }
    //     var metrics = _store.GetMetricsByTaskId(id);
    //     return Ok(metrics);
    // }
}