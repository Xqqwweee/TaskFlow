using Microsoft.AspNetCore.Mvc;
using TaskFlow.Dtos;
using TaskFlow.Interfaces.Services;

namespace TaskFlow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ResponseProjectDto>>> GetAll()
    {
        return await _projectService.GetAllAsync();
    }

    [HttpGet("{id}", Name = "GetProjectByIdRoute")]
    public async Task<ActionResult<ResponseProjectDto>> GetById(int id)
    {
        var project = await _projectService.GetByIdAsync(id);
        if (project is null)
        {
            return NotFound();
        }

        return project;
    }

    [HttpPost]
    public async Task<ActionResult<ResponseProjectDto>> Create([FromBody] CreateProjectDto dto)
    {
        var project = await _projectService.CreateAsync(dto);

        return CreatedAtRoute("GetProjectByIdRoute", new { id = project.Id }, project);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProjectDto dto)
    {
        var isUpdated = await _projectService.UpdateAsync(id, dto);
        if (!isUpdated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await _projectService.DeleteAsync(id);
        if (!isDeleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}