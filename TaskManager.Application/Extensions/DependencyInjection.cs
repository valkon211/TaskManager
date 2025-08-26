using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Interfaces.Services;
using TaskManager.Application.Mapping;
using TaskManager.Application.Services;

namespace TaskManager.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<ITaskService, TaskService>();
        services.AddTransient<TaskMapper>();
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}