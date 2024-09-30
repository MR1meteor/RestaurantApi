using Microsoft.Extensions.Configuration;
using Restaurant.Infrastructure.Common.Dapper.Interfaces;

namespace Restaurant.Infrastructure.Common.Dapper;

public class DapperSettings : IDapperSettings
{
    public DapperSettings(IConfiguration configuration)
    {
        ConnectionString = configuration["Connections:Database"] ??
                           throw new ArgumentException("Set database connection string");
    }

    public string ConnectionString { get; }
}