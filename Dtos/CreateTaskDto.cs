using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Dtos;

public record CreateTaskDto([Required]
    string Title,
    string Description,
    DateTime? Deadline,
    int ProjectId
    );
