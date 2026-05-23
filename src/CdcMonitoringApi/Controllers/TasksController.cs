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
}