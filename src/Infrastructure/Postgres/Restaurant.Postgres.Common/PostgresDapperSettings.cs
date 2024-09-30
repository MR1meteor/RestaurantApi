using Microsoft.Extensions.Configuration;
using Restaurant.Infrastructure.Common.Dapper.Interfaces;

namespace Restaurant.Postgres.Common;

public class PostgresDapperSettings : IDapperSettings
{
    private readonly IConfiguration _configuration;

    public PostgresDapperSettings(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string ConnectionString => _configuration["Connections:Postgres"];
}