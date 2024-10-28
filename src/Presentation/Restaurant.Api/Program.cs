using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Restaurant.Common.DependencyInjection;
using Restaurant.Common.DependencyInjection.Interfaces;
using Restaurant.Infrastructure.Common.Dapper;
using Restaurant.Infrastructure.Common.Dapper.Interfaces;
using Restaurant.Postgres.Common;
using Restaurant.Postgres.Migration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDapperSettings, PostgresDapperSettings>();
builder.Services.AddSingleton<IDapperContext, DapperContext>();
BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
builder.Services.RegisterAllTypes<IDependency>(typeof(Program).Assembly);
builder.Services.AddStackExchangeRedisCache(opts =>
{
    opts.Configuration = builder.Configuration["Connections:Redis"];
    opts.InstanceName = builder.Configuration["RedisCacheInstance"];
});
builder.Services.AddLogging(b => b.AddConsole());
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddPostgresMigrationRunner();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "restaurant-api"); });
app.UseHttpsRedirection().UseRouting().UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();