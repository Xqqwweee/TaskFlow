using Microsoft.EntityFrameworkCore;
using TaskFlow.Data;
using TaskFlow.Interfaces.Repositories;
using TaskFlow.Models;

namespace TaskFlow.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly TaskFlowDbContext _context;
    private readonly ILogger<TaskRepository> _logger;

    public TaskRepository(TaskFlowDbContext context, ILogger<TaskRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<TaskItem>> GetAllAsync()
    {
        return await _context.Tasks.AsNoTracking().ToListAsync();
    }

    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        return await _context.Tasks.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<TaskItem> CreateAsync(TaskItem taskItem)
    {
        _context.Tasks.Add(taskItem);
        await _context.SaveChangesAsync();
        return taskItem;
    }

    public async Task UpdateAsync(TaskItem taskItem)
    {
        _context.Tasks.Update(taskItem);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var taskItem = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        if (taskItem is null)
        {
            _logger.LogWarning("Task with Id: {id} was not found.", id);
            return false;
        }

        _context.Tasks.Remove(taskItem);
        await _context.SaveChangesAsync();

        return true;
    }
}
