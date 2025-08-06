using TaskManager.Core.Models;

namespace TaskManager.Infrastructure.Interfaces;

public interface ITaskRepository
{
    public Task Create(TaskEntity task);

    public Task DeleteByUid(Guid taskId);

    public Task Update(TaskEntity task);

    public Task<TaskEntity> GetByUid(Guid taskId);

    public Task<IEnumerable<TaskEntity>> GetAll();
}