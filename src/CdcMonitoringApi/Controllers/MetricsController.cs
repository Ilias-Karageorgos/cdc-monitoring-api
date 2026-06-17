using Microsoft.AspNetCore.Mvc;
using CdcMonitoringApi.Models.Dtos;
using CdcMonitoringApi.IRepositories;
using System.ComponentModel.DataAnnotations;

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
        
        if (!await _taskRepo.ExistsAsync(taskId))
        {
            return NotFound();
        }

        var metrics = await _metricRepo.GetByTaskIdAsync(taskId);
        var metricDtos = metrics.Select(TaskMetricDto.FromEntity);
        return Ok(metricDtos);
    }

    [HttpGet("summary")]
    public async Task<ActionResult<MetricsSummaryDto>> GetMetricsSummary(
        int taskId,
        [FromQuery, Range(1, 1440)] int sinceMinutes = 60)
    {
        if (!await _taskRepo.ExistsAsync(taskId))
        {
            return NotFound();
        }

        var summary = await _metricRepo.GetSummaryAsync(taskId, sinceMinutes);

        if (summary == null)
        {
            return NotFound();
        }

        return Ok(summary);
    }

}
