namespace TaskManager.API.Models;

public class CreateTaskRequest
{
    public string Title { get; set; }
    
    public string Description { get; set; }
}