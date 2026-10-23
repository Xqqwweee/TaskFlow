namespace TaskFlow.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? Deadline { get; set; }
        public TaskItemStatus Status { get; set; } = TaskItemStatus.Open;
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;

    }
}
