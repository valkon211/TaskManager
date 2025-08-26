using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Infrastructure.Data;
using TaskManager.Infrastructure.Interfaces;
using TaskManager.Infrastructure.Repositories;

namespace TaskManager.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDatabaseContext>(_ => new DatabaseContext(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddScoped<ITaskRepository, TaskRepository>();
        
        return services;
    }
}