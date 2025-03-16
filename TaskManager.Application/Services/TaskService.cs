using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces.Services;

namespace TaskManager.Application.Services;

public class TaskService : ITaskService
{
    public Task CreateTaskAsync(string title, string description)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTaskAsync(TaskDto task)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTaskAsync(TaskDto task)
    {
        throw new NotImplementedException();
    }
}