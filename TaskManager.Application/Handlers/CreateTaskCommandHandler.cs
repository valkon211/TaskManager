using TaskManager.Application.Commands;
using TaskManager.Application.Interfaces.Services;

namespace TaskManager.Application.Handlers;

public class CreateTaskCommandHandler : EmptyResponseCommandHandler<CreateTaskCommand>
{
    private readonly ITaskService _taskService;

    public CreateTaskCommandHandler(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    public override async Task HandleCommandAsync(CreateTaskCommand command)
    {
        await _taskService.CreateTaskAsync(command.Title, command.Description);
    }
}