using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Dtos;

public record CreateTaskDto([Required(ErrorMessage = "Title is required.")]
    string Title,
    string? Description,
    DateTime? Deadline,
    int ProjectId
    );
