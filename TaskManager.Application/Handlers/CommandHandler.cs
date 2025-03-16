using TaskManager.Application.Commands;

namespace TaskManager.Application.Handlers;

public abstract class CommandHandler<TCommand, TResponse>
{
    public abstract Task<TResponse> HandleCommandAsync(TCommand command);
}