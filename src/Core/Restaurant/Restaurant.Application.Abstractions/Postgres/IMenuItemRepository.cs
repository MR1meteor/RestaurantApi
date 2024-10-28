using Restaurant.Application.Domain.Postgres;
using Restaurant.Common.DependencyInjection.Interfaces;

namespace Restaurant.Application.Abstractions.Postgres;

public interface IMenuItemRepository : ITransient
{
    Task<List<DbMenuItem>> GetAllAsync();
    Task<DbMenuItem?> GetByIdAsync(int id);
    Task CreateAsync(DbMenuItem menu);
    Task UpdateAsync(DbMenuItem menu);
    Task DeleteByIdAsync(int id);
}