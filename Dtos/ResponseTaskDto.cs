using TaskFlow.Models;

namespace TaskFlow.Dtos;

public class ResponseTaskDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime? Deadline { get; set; }
    public TaskItemStatus Status { get; set; } = TaskItemStatus.Open;
    public int ProjectId { get; set; }

    public static ResponseTaskDto ToDto(TaskItem taskItem)
    {
        ResponseTaskDto newDto = new ()
        {
            Id = taskItem.Id,
            Title = taskItem.Title,
            Description = taskItem.Description,
            Deadline = taskItem.Deadline,
            Status = taskItem.Status,
            ProjectId = taskItem.ProjectId,
        };
        return newDto;
    }
}
