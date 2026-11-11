using TaskFlow.Dtos;

namespace TaskFlow.Interfaces.Services;

public interface ITaskService
{
    Task<List<ResponseTaskDto>> GetAllAsync();
    Task<ResponseTaskDto?> GetByIdAsync(int id);
    Task<ResponseTaskDto> CreateAsync(CreateTaskDto dto);
    Task<bool> UpdateAsync(int id, UpdateTaskDto dto);
    Task<bool> DeleteAsync(int id);
}
