using Restaurant.Application.Abstractions;
using Restaurant.Application.Domain.PostgresDb;
using Restaurant.Infrastructure.Common.Dapper;
using Restaurant.Infrastructure.Common.Dapper.Interfaces;
using Restaurant.Postgres.Infrastructure.Scripts.MenuItem;

namespace Restaurant.Postgres.Infrastructure;

public class MenuItemRepository : IMenuItemRepository
{
    private readonly IDapperContext _dapperContext;

    public MenuItemRepository(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }
    
    public async Task<List<DbMenuItem>> GetAllAsync()
    {
        var queryObject = new QueryObject(PostgresMenuItem.GetAll, new { });
        return await _dapperContext.ListOrEmpty<DbMenuItem>(queryObject) ?? new List<DbMenuItem>();
    }

    public async Task<DbMenuItem?> GetByIdAsync(int id)
    {
        var queryObject = new QueryObject(PostgresMenuItem.GetById, new { Id = id });
        return await _dapperContext.FirstOrDefault<DbMenuItem>(queryObject);
    }

    public async Task CreateAsync(DbMenuItem menu)
    {
        var queryObject = new QueryObject(PostgresMenuItem.Insert, menu);
        await _dapperContext.Command<DbMenuItem>(queryObject);
    }

    public async Task UpdateAsync(DbMenuItem menu)
    {
        var queryObject = new QueryObject(PostgresMenuItem.Update, menu);
        await _dapperContext.Command<DbMenuItem>(queryObject);
    }

    public async Task DeleteByIdAsync(int id)
    {
        var queryObject = new QueryObject(PostgresMenuItem.Delete, new { Id = id });
        await _dapperContext.Command<object>(queryObject);
    }
}