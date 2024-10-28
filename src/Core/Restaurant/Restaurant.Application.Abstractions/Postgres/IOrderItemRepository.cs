using Restaurant.Application.Domain.Postgres;
using Restaurant.Common.DependencyInjection.Interfaces;

namespace Restaurant.Application.Abstractions.Postgres;

public interface IOrderItemRepository : ITransient
{
    Task<List<DbOrderItem>> GetAllAsync();
    Task<DbOrderItem?> GetByIdAsync(int id);
    Task CreateAsync(DbOrderItem orderItem);
    Task UpdateAsync(DbOrderItem orderItem);
    Task DeleteByIdAsync(int id);
}