using Restaurant.Application.Abstractions;
using Restaurant.Application.Domain.PostgresDb;
using Restaurant.Infrastructure.Common.Dapper;
using Restaurant.Infrastructure.Common.Dapper.Interfaces;
using Restaurant.Postgres.Infrastructure.Scripts.Order;

namespace Restaurant.Postgres.Infrastructure;

public class OrderRepository : IOrderRepository
{
    private readonly IDapperContext _dapperContext;

    public OrderRepository(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }
    
    public async Task<List<DbOrder>> GetAllAsync()
    {
        var queryObject = new QueryObject(PostgresOrder.GetAll, new { });
        return await _dapperContext.ListOrEmpty<DbOrder>(queryObject) ?? new List<DbOrder>();
    }

    public async Task<DbOrder?> GetByIdAsync(int id)
    {
        var queryObject = new QueryObject(PostgresOrder.GetById, new { Id = id });
        return await _dapperContext.FirstOrDefault<DbOrder>(queryObject);
    }

    public async Task CreateAsync(DbOrder order)
    {
        var queryObject = new QueryObject(PostgresOrder.Insert, order);
        await _dapperContext.Command<DbOrder>(queryObject);
    }

    public async Task UpdateAsync(DbOrder order)
    {
        var queryObject = new QueryObject(PostgresOrder.Update, order);
        await _dapperContext.Command<DbOrder>(queryObject);
    }

    public async Task DeleteByIdAsync(int id)
    {
        var queryObject = new QueryObject(PostgresOrder.Delete, new { Id = id });
        await _dapperContext.Command<object>(queryObject);
    }
}