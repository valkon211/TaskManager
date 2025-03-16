using TaskManager.Application.DTOs;

namespace TaskManager.Application.Interfaces.Services;

public interface ITaskService
{
    public Task CreateTaskAsync(string title, string description);
    
    public Task UpdateTaskAsync(TaskDto task);
    
    public Task DeleteTaskAsync(TaskDto task);
}