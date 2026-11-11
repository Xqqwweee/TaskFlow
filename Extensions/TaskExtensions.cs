using TaskFlow.Dtos;
using TaskFlow.Models;

namespace TaskFlow.Extensions;

public static class TaskExtensions
{
    public static ResponseTaskDto ToDto(this TaskItem taskItem)
    {
        return new ResponseTaskDto
        {
            Id = taskItem.Id,
            Title = taskItem.Title,
            Description = taskItem.Description,
            Deadline = taskItem.Deadline,
            Status = taskItem.Status,
            ProjectId = taskItem.ProjectId,
        };
    }
}
