using TaskManager.Application.DTOs;
using TaskManager.Core.Models;
using TaskStatus = TaskManager.Core.Models.TaskStatus;

namespace TaskManager.Application.Mapping;

public class TaskMapper
{
    public TaskDto CreateDto(TaskEntity entity)
    {
        return new TaskDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            Status = entity.Status.ToString()
        };
    }

    public TaskEntity CreateEntity(TaskDto dto)
    {
        return new TaskEntity
        {
            Id = dto.Id,
            Title = dto.Title,
            Description = dto.Description,
            Status = Enum.TryParse<TaskStatus>(dto.Status, out var status)
                ? status
                : throw new ArgumentException($"Недопустимый статус: {dto.Status}")
        };
    }
}