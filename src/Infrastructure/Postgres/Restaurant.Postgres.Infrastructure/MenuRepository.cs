using Restaurant.Application.Abstractions.Postgres;
using Restaurant.Application.Domain.Postgres;
using Restaurant.Infrastructure.Common.Dapper;
using Restaurant.Infrastructure.Common.Dapper.Interfaces;
using Restaurant.Postgres.Infrastructure.Scripts.Menu;

namespace Restaurant.Postgres.Infrastructure;

public class MenuRepository : IMenuRepository
{
    private readonly IDapperContext _dapperContext;

    public MenuRepository(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<List<DbMenu>> GetAllAsync()
    {
        var queryObject = new QueryObject(PostgresMenu.GetAll, new { });
        return await _dapperContext.ListOrEmpty<DbMenu>(queryObject) ?? new List<DbMenu>();
    }

    public async Task<DbMenu?> GetByIdAsync(int id)
    {
        var queryObject = new QueryObject(PostgresMenu.GetById, new { Id = id });
        return await _dapperContext.FirstOrDefault<DbMenu>(queryObject);
    }

    public async Task CreateAsync(DbMenu menu)
    {
        var queryObject = new QueryObject(PostgresMenu.Insert, menu);
        await _dapperContext.Command<DbMenu>(queryObject);
    }

    public async Task UpdateAsync(DbMenu menu)
    {
        var queryObject = new QueryObject(PostgresMenu.Update, menu);
        await _dapperContext.Command<DbMenu>(queryObject);
    }

    public async Task DeleteByIdAsync(int id)
    {
        var queryObject = new QueryObject(PostgresMenu.Delete, new { Id = id });
        await _dapperContext.Command<object>(queryObject);
    }
}