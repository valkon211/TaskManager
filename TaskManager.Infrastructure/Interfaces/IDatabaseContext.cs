using Npgsql;

namespace TaskManager.Infrastructure.Interfaces;

public interface IDatabaseContext
{
    Task<NpgsqlConnection> CreateConnectionAsync();
}