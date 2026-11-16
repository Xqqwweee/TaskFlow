using Microsoft.AspNetCore.Mvc;
using TaskFlow.Dtos;
using TaskFlow.Interfaces.Services;

namespace TaskFlow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskItemsController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskItemsController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ResponseTaskDto>>> GetAll()
    {
        return await _taskService.GetAllAsync();
    }

    [HttpGet("{id}", Name = "GetTaskByIdRoute")]
    public async Task<ActionResult<ResponseTaskDto>> GetById(int id)
    {
        var taskItem = await _taskService.GetByIdAsync(id);
        if (taskItem is null)
        {
            return NotFound();
        }

        return taskItem;
    }

    [HttpPost]
    public async Task<ActionResult<ResponseTaskDto>> Create([FromBody] CreateTaskDto dto)
    {
        var newTask = await _taskService.CreateAsync(dto);

        return CreatedAtRoute("GetTaskByIdRoute", new { id = newTask.Id }, newTask);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTaskDto dto)
    {
        var isUpdated = await _taskService.UpdateAsync(id, dto);

        if (!isUpdated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await _taskService.DeleteAsync(id);

        if (!isDeleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
