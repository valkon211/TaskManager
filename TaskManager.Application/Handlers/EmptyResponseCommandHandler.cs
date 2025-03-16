namespace TaskManager.Application.Handlers;

public abstract class EmptyResponseCommandHandler<TCommand>
{
    public abstract Task HandleCommandAsync(TCommand command);
}