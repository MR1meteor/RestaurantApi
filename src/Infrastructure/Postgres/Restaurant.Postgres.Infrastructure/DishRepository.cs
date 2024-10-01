using Restaurant.Application.Abstractions;
using Restaurant.Application.Domain.PostgresDb;
using Restaurant.Infrastructure.Common.Dapper;
using Restaurant.Infrastructure.Common.Dapper.Interfaces;
using Restaurant.Postgres.Infrastructure.Scripts.Dish;

namespace Restaurant.Postgres.Infrastructure;

public class DishRepository : IDishRepository
{
    private readonly IDapperContext _dapperContext;

    public DishRepository(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }
    
    public async Task<List<DbDish>> GetAllAsync()
    {
        var queryObject = new QueryObject(PostgresDish.GetAll, new { });
        return await _dapperContext.ListOrEmpty<DbDish>(queryObject) ?? new List<DbDish>();
    }

    public async Task<DbDish?> GetByIdAsync(int id)
    {
        var queryObject = new QueryObject(PostgresDish.GetById, new { Id = id });
        return await _dapperContext.FirstOrDefault<DbDish>(queryObject);
    }

    public async Task CreateAsync(DbDish dish)
    {
        var queryObject = new QueryObject(PostgresDish.Insert, dish);
        await _dapperContext.Command<DbDish>(queryObject);
    }

    public async Task UpdateAsync(DbDish dish)
    {
        var queryObject = new QueryObject(PostgresDish.Update, dish);
        await _dapperContext.Command<DbDish>(queryObject);
    }

    public async Task DeleteByIdAsync(int id)
    {
        var queryObject = new QueryObject(PostgresDish.Delete, new { Id = id });
        await _dapperContext.Command<object>(queryObject);
    }
}