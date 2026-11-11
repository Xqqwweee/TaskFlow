using TaskFlow.Dtos;
using TaskFlow.Extensions;
using TaskFlow.Interfaces.Repositories;
using TaskFlow.Interfaces.Services;
using TaskFlow.Models;

namespace TaskFlow.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly ILogger<TaskService> _logger;

    public TaskService(ITaskRepository taskRepository, ILogger<TaskService> logger)
    {
        _taskRepository = taskRepository;
        _logger = logger;
    }

    public async Task<List<ResponseTaskDto>> GetAllAsync()
    {
        _logger.LogInformation("Starting to retrieve all tasks...");
        var tasksList = await _taskRepository.GetAllAsync();
        int count = tasksList.Count;
        _logger.LogInformation("Successfully retrieved {count} tasks.", count);
        return tasksList
            .Select(t => t.ToDto())
            .ToList();
    }

    public async Task<ResponseTaskDto?> GetByIdAsync(int id)
    {
        var taskItem = await _taskRepository.GetByIdAsync(id);
        if (taskItem is null)
        {
            _logger.LogWarning("Task with Id: {id} was not found.", id);
            return null;
        }

        return taskItem.ToDto();
    }

    public async Task<ResponseTaskDto> CreateAsync(CreateTaskDto dto)
    {
        TaskItem taskItem = new ()
        {
            Title = dto.Title,
            Description = dto.Description,
            Deadline = dto.Deadline,
            ProjectId = dto.ProjectId,
        };
        var createdTaskItem = await _taskRepository.CreateAsync(taskItem);
        return createdTaskItem.ToDto();
    }

    public async Task<bool> UpdateAsync(int id, UpdateTaskDto dto)
    {
        var taskItem = await _taskRepository.GetByIdAsync(id);
        if (taskItem is null)
        {
            _logger.LogWarning("Task with Id: {id} was not found.", id);
            return false;
        }

        taskItem.Title = dto.Title;
        taskItem.Description = dto.Description;
        taskItem.Deadline = dto.Deadline;
        taskItem.ProjectId = dto.ProjectId;

        await _taskRepository.UpdateAsync(taskItem);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _taskRepository.DeleteAsync(id);
    }
}
