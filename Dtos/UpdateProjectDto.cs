using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Dtos;

public record UpdateProjectDto([Required] string Name);
