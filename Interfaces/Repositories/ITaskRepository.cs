using TaskFlow.Models;

namespace TaskFlow.Interfaces.Repositories;

public interface ITaskRepository
{
    Task<List<TaskItem>> GetAllAsync();
    Task<TaskItem?> GetByIdAsync(int id);
    Task<TaskItem> CreateAsync(TaskItem taskItem);
    Task UpdateAsync(TaskItem taskItem);
    Task<bool> DeleteAsync(int id);
}
