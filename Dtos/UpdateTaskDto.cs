using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Dtos;

public record UpdateTaskDto([Required(ErrorMessage = "Title is required.")]
    string Title,
    string? Description,
    DateTime? Deadline,
    int ProjectId
    );
