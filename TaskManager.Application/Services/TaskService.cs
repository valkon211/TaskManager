using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces.Services;
using TaskManager.Application.Mapping;
using TaskManager.Core.Models;
using TaskManager.Infrastructure.Interfaces;

namespace TaskManager.Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly TaskMapper _taskMapper;

    public TaskService(ITaskRepository taskRepository, TaskMapper taskMapper)
    {
        _taskRepository = taskRepository;
        _taskMapper = taskMapper;
    }
    
    public async Task CreateTaskAsync(string title, string description)
    {
        await _taskRepository.Create(new TaskEntity { Title = title, Description = description });
    }

    public async Task UpdateTaskAsync(TaskDto task)
    {
        await _taskRepository.Update(_taskMapper.CreateEntity(task));
    }

    public async Task DeleteTaskAsync(TaskDto task)
    {
        await _taskRepository.DeleteByUid(task.Id);
    }
}