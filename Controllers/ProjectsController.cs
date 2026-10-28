using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Data;
using TaskFlow.Models;
using TaskFlow.Dtos;

namespace TaskFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly TaskFlowDbContext _db;
        public ProjectsController(TaskFlowDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseProjectDto>>> GetAll()
        {
            List<ResponseProjectDto> projects = await _db.Projects
                .Select(x => ResponseProjectDto.ToDto(x))
                .ToListAsync();
            return Ok(projects);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseProjectDto>> Create(CreateProjectDto dto)
        {
            var project = new Project { Name = dto.Name };
            _db.Projects.Add(project);
            await _db.SaveChangesAsync();
            return Created("", ResponseProjectDto.ToDto(project));
        }
    }
}
