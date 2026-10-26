using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Data;
using TaskFlow.Models;

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
        public async Task<ActionResult<List<Project>>> GetAll()
        {
            var projects = await _db.Projects.ToListAsync();
            return Ok(projects);
        }
    }
}
