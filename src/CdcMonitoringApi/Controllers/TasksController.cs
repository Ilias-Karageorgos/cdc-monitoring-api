using Microsoft.AspNetCore.Mvc;
using CdcMonitoringApi.IRepositories;
using CdcMonitoringApi.Models.Dtos;


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
    public async Task<ActionResult<IEnumerable<ReplicationTaskDto>>> GetTasks()
    {
        var tasks = await _repo.GetAllAsync();
        var taskDtos = tasks.Select(ReplicationTaskDto.FromEntity);
        return Ok(taskDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReplicationTaskDto>> GetTaskById(int id)
    {
        var task = await _repo.GetByIdAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(ReplicationTaskDto.FromEntity(task));
    }
}