namespace TaskManager.Application.Commands;

public class UpdateTaskCommand
{
    public Guid TaskId { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string DueDate { get; set; }
}