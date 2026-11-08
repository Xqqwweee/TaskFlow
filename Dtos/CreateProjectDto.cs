using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Dtos;

public record CreateProjectDto([Required] string Name);
