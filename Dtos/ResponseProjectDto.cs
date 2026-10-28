using TaskFlow.Models;

namespace TaskFlow.Dtos
{
    public class ResponseProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
        public static ResponseProjectDto ToDto(Project project)
        {
            ResponseProjectDto newDto = new();
            newDto.Name = project.Name;
            newDto.Id = project.Id;
            return newDto;
        }
    }
}
