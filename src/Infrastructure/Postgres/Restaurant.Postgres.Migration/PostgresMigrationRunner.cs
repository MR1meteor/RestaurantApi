using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Microsoft.Extensions.DependencyInjection;

namespace Restaurant.Postgres.Migration;

public static class PostgresMigrationRunner
{
    public static IServiceCollection AddPostgresMigrationRunner(this IServiceCollection services)
    {
        var serviceProvider = services.AddSingleton<IConnectionStringReader, SettingsConnectionStringReader>()
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb.AddPostgres().ScanIn(typeof(SettingsConnectionStringReader).Assembly)
                .For.Migrations().For.EmbeddedResources()).BuildServiceProvider();
        
        using (var scope = serviceProvider.CreateScope())
        {
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
        
        return services;
    }
}