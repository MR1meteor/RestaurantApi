using Restaurant.Application.Abstractions.Postgres;
using Restaurant.Application.Domain.Postgres;
using Restaurant.Infrastructure.Common.Dapper;
using Restaurant.Infrastructure.Common.Dapper.Interfaces;
using Restaurant.Postgres.Infrastructure.Scripts.OrderItem;

namespace Restaurant.Postgres.Infrastructure;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly IDapperContext _dapperContext;

    public OrderItemRepository(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<List<DbOrderItem>> GetAllAsync()
    {
        var queryObject = new QueryObject(PostgresOrderItem.GetAll, new { });
        return await _dapperContext.ListOrEmpty<DbOrderItem>(queryObject) ?? new List<DbOrderItem>();
    }

    public async Task<DbOrderItem?> GetByIdAsync(int id)
    {
        var queryObject = new QueryObject(PostgresOrderItem.GetById, new { Id = id });
        return await _dapperContext.FirstOrDefault<DbOrderItem>(queryObject);
    }

    public async Task CreateAsync(DbOrderItem orderItem)
    {
        var queryObject = new QueryObject(PostgresOrderItem.Insert, orderItem);
        await _dapperContext.Command<DbOrderItem>(queryObject);
    }

    public async Task UpdateAsync(DbOrderItem orderItem)
    {
        var queryObject = new QueryObject(PostgresOrderItem.Update, orderItem);
        await _dapperContext.Command<DbOrderItem>(queryObject);
    }

    public async Task DeleteByIdAsync(int id)
    {
        var queryObject = new QueryObject(PostgresOrderItem.Delete, new { Id = id });
        await _dapperContext.Command<object>(queryObject);
    }
}