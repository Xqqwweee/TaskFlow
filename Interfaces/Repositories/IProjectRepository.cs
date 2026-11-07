using Microsoft.AspNetCore.Mvc;
using TaskFlow.Models;

namespace TaskFlow.Interfaces.Repositories;

public interface IProjectRepository
{
    Task<List<Project>> GetAllAsync();
    Task<Project?> GetByIdAsync(int id);
    Task<Project> CreateAsync(Project project);
    Task UpdateAsync(Project project);
    Task<bool> DeleteAsync(int id);
}
