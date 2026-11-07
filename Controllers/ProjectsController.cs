using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Data;
using TaskFlow.Dtos;
using TaskFlow.Extensions;
using TaskFlow.Models;

namespace TaskFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    internal class ProjectsController(TaskFlowDbContext context) : ControllerBase
    {
        private readonly TaskFlowDbContext _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<ResponseProjectDto> projects = await _context.Projects
                .Select(p => new ResponseProjectDto
                {
                    Id = p.Id,
                    Name = p.Name,
                })
                .ToListAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseProjectDto>> GetById(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project is null)
            {
                return NotFound();
            }

            return Ok(ResponseProjectDto.ToDto(project));
        }

        [HttpPost]
        public async Task<ActionResult<ResponseProjectDto>> Create(CreateProjectDto dto)
        {
            var project = new Project { Name = dto.name };
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = project.Id }, ResponseProjectDto.ToDto(project));
        }
    }
}
