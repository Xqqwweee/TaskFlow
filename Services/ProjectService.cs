using TaskFlow.Dtos;
using TaskFlow.Extensions;
using TaskFlow.Interfaces.Repositories;
using TaskFlow.Interfaces.Services;
using TaskFlow.Models;

namespace TaskFlow.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly ILogger<ProjectService> _logger;

    public ProjectService(IProjectRepository projectRepository, ILogger<ProjectService> logger)
    {
        _projectRepository = projectRepository;
        _logger = logger;
    }

    public async Task<List<ResponseProjectDto>> GetAllAsync()
    {
        _logger.LogInformation("Starting to retrieve all projects...");
        var projects = await _projectRepository.GetAllAsync();
        int projectsCount = projects.Count;
        _logger.LogInformation("Successfully retrieved {count} projects.", projectsCount);
        return projects
            .Select(p => p.ToDto())
            .ToList();
    }

    public async Task<ResponseProjectDto?> GetByIdAsync(int id)
    {
        var project = await _projectRepository.GetByIdAsync(id);
        if (project is null)
        {
            _logger.LogWarning("Project with Id: {id} was not found.", id);
            return null;
        }

        return project.ToDto();
    }

    public async Task<ResponseProjectDto> CreateAsync(CreateProjectDto createProjectDto)
    {
        var project = new Project
        {
            Name = createProjectDto.Name,
        };
        var createdProject = await _projectRepository.CreateAsync(project);
        return createdProject.ToDto();
    }

    public async Task<bool> UpdateAsync(int id, UpdateProjectDto updateProjectDto)
    {
        var project = await _projectRepository.GetByIdAsync(id);
        if (project is null)
        {
            _logger.LogWarning("Project with Id: {id} was not found.", id);
            return false;
        }

        project.Name = updateProjectDto.Name;
        await _projectRepository.UpdateAsync(project);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _projectRepository.DeleteAsync(id);
    }
}
