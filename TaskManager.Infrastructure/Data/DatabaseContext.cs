using Npgsql;
using TaskManager.Infrastructure.Interfaces;

namespace TaskManager.Infrastructure.Data;

public class DatabaseContext: IDatabaseContext
{
    private readonly string _connectionString;

    public DatabaseContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public async Task<NpgsqlConnection> CreateConnectionAsync()
    {
        var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();
        return connection;
    }
}