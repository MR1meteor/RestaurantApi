using Restaurant.Application.Domain.Postgres;
using Restaurant.Common.DependencyInjection.Interfaces;

namespace Restaurant.Application.Abstractions.Postgres;

public interface IOrderRepository : ITransient
{
    Task<List<DbOrder>> GetAllAsync();
    Task<DbOrder?> GetByIdAsync(int id);
    Task CreateAsync(DbOrder order);
    Task UpdateAsync(DbOrder order);
    Task DeleteByIdAsync(int id);
}