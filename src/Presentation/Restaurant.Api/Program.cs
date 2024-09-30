using Restaurant.Common.DependencyInjection;
using Restaurant.Common.DependencyInjection.Interfaces;
using Restaurant.Infrastructure.Common.Dapper;
using Restaurant.Infrastructure.Common.Dapper.Interfaces;
using Restaurant.Postgres.Common;
using Restaurant.Postgres.Migration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDapperSettings, PostgresDapperSettings>();
builder.Services.AddSingleton<IDapperContext, DapperContext>();
builder.Services.RegisterAllTypes<IDependency>(typeof(Program).Assembly);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddPostgresMigrationRunner();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "restaurant-api"); });
app.UseHttpsRedirection().UseRouting().UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();