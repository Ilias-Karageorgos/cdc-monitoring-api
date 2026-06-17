using CdcMonitoringApi.IRepositories;
using CdcMonitoringApi.Data;
using CdcMonitoringApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CdcMonitoringApi.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _context;

    public TaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ReplicationTask>> GetAllAsync()
    {
        return await _context.ReplicationTasks.ToListAsync();
    }

    public async Task<ReplicationTask?> GetByIdAsync(int id)
    {
        return await _context.ReplicationTasks.FindAsync(id);
    }

    public Task<bool> ExistsAsync(int id) =>
    _context.ReplicationTasks.AnyAsync(t => t.Id == id);

}
