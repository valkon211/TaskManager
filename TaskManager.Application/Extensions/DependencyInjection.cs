using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Interfaces.Services;
using TaskManager.Application.Services;

namespace TaskManager.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<ITaskService, TaskService>();
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}