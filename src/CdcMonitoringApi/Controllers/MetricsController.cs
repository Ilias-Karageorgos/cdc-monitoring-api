using Microsoft.AspNetCore.Mvc;
using CdcMonitoringApi.Models.Dtos;
using CdcMonitoringApi.IRepositories;

namespace CdcMonitoringApi.Controllers;

[ApiController]
[Route("tasks/{taskId}/metrics")]
public class MetricsController : ControllerBase
{
    private readonly ITaskRepository _taskRepo;
    private readonly IMetricRepository _metricRepo;

    public MetricsController(ITaskRepository taskRepo, IMetricRepository metricRepo)
    {
        _taskRepo = taskRepo;
        _metricRepo = metricRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskMetricDto>>> GetTaskMetrics(int taskId)
    {
        var task = await _taskRepo.GetByIdAsync(taskId);
        if (task == null)
        {
            return NotFound();
        }
        var metrics = await _metricRepo.GetByTaskIdAsync(taskId);
        var metricDtos = metrics.Select(TaskMetricDto.FromEntity);
        return Ok(metricDtos);
    }
}
