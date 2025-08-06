using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Models;
using TaskManager.Infrastructure.Interfaces;
using TaskStatus = TaskManager.Core.Models.TaskStatus;

namespace TaskManager.Infrastructure.Repositories;

public class TaskRepository: ITaskRepository
{
    private readonly AppDbContext _dbContext;

    public TaskRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task Create(TaskEntity task)
    {
        await _dbContext.Tasks.AddAsync(task);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteByUid(Guid taskId)
    {
        var task = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);

        if (task == null)
            throw new Exception($"Task with Id = {taskId} does not exists.");

        _dbContext.Tasks.Remove(task);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(TaskEntity task)
    {
        var exTask = await _dbContext.Tasks.FindAsync(task);

        if (exTask == null)
            throw new Exception($"Task with Id = {task.Id} does not exists.");

        _dbContext.Tasks.Update(exTask);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<TaskEntity> GetByUid(Guid taskId)
    {
        var task = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);
        
        if (task == null)
            throw new Exception($"Task with Id = {taskId} does not exists.");

        return task;
    }

    public async Task<IEnumerable<TaskEntity>> GetAll()
    {
        return await _dbContext.Tasks.ToArrayAsync();
    }
}