using Microsoft.AspNetCore.Mvc;
using CdcMonitoringApi.Models;
using CdcMonitoringApi.IRepositories;


namespace CdcMonitoringApi.Controllers;

[ApiController]
[Route("tasks")]
public class TasksController : ControllerBase
{
    private readonly ITaskRepository _repo;
    private readonly IMetricRepository _metricRepo;

    public TasksController(ITaskRepository repo, IMetricRepository metricRepo)
    {
        _repo = repo;
        _metricRepo = metricRepo;
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


    [HttpGet("{id}/metrics")]
    public async Task<ActionResult<IEnumerable<TaskMetric>>> GetTaskMetrics(int id)
    {
        var task = await _repo.GetByIdAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        var metrics = await _metricRepo.GetByTaskIdAsync(id);
        return Ok(metrics);
    }
}