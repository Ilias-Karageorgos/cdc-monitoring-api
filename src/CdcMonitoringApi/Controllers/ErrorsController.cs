using Microsoft.AspNetCore.Mvc;
using CdcMonitoringApi.IRepositories;
using CdcMonitoringApi.Models.Dtos;
using System.ComponentModel.DataAnnotations;

namespace CdcMonitoringApi.Controllers;


[ApiController]
[Route("tasks/{taskId}/errors")]
public class ErrorsController : ControllerBase
{
    private readonly IErrorRepository _errorRepository;
    private readonly ITaskRepository _taskRepository;

    public ErrorsController(IErrorRepository errorRepository, ITaskRepository taskRepository)
    {
        _errorRepository = errorRepository;
        _taskRepository = taskRepository;
    }

    [HttpGet("summary")]
    public async Task<ActionResult<TaskErrorSummaryDto>> GetErrorsSummary(
    int taskId,
    [FromQuery, Range(1, 1440)] int sinceMinutes = 60)
    {

        var taskExists = await _taskRepository.ExistsAsync(taskId);
        if (!taskExists)
        {
            return NotFound();
        }

        var summary = await _errorRepository.GetSummaryAsync(taskId, sinceMinutes);

        if (summary == null)
        {
            return NotFound();
        }

        return Ok(summary);
    }
}
