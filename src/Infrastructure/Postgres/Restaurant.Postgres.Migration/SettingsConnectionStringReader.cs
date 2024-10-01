using FluentMigrator.Runner.Initialization;
using Microsoft.Extensions.Configuration;

namespace Restaurant.Postgres.Migration;

public class SettingsConnectionStringReader : IConnectionStringReader
{
    private readonly IConfiguration _configuration;

    public SettingsConnectionStringReader(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string GetConnectionString(string connectionStringOrName)
    {
        return _configuration["Connections:Postgres"];
    }

    public int Priority => int.MaxValue;
}