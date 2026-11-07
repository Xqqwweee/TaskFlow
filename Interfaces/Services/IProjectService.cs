using TaskFlow.Dtos;
using TaskFlow.Models;

namespace TaskFlow.Interfaces.Services;

public interface IProjectService
{
    Task<List<ResponseProjectDto>> GetAllAsync();
    Task<ResponseProjectDto?> GetByIdAsync(int id);
    Task<ResponseProjectDto> CreateAsync(CreateProjectDto dto);
    Task UpdateAsync(int id, UpdateProjectDto dto);
    Task<bool> DeleteAsync(int id);
}
