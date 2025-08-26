using TaskManager.Core.Models;
using TaskManager.Infrastructure.Interfaces;

namespace TaskManager.Infrastructure.Repositories;

public class TaskRepository: ITaskRepository
{
    private readonly IDatabaseContext _dbContext;

    public TaskRepository(IDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task Create(TaskEntity task)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByUid(Guid taskId)
    {
        throw new NotImplementedException();
    }

    public Task Update(TaskEntity task)
    {
        throw new NotImplementedException();
    }

    public Task<TaskEntity> GetByUid(Guid taskId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TaskEntity>> GetAll()
    {
        throw new NotImplementedException();
    }
}