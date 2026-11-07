namespace TaskFlow.Extensions;

using TaskFlow.Models;
using TaskFlow.Dtos;

public static class ProjectExtensions
{
    public static ResponseProjectDto ToDto(this Project project)
    {
        return new ResponseProjectDto
        {
            Id = project.Id,
            Name = project.Name,
        };
    }
}