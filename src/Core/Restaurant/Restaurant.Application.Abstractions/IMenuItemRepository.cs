using Restaurant.Application.Domain.PostgresDb;
using Restaurant.Common.DependencyInjection.Interfaces;

namespace Restaurant.Application.Abstractions;

public interface IMenuItemRepository : ITransient
{
    Task<List<DbMenuItem>> GetAllAsync();
    Task<DbMenuItem?> GetByIdAsync(int id);
    Task CreateAsync(DbMenuItem menu);
    Task UpdateAsync(DbMenuItem menu);
    Task DeleteByIdAsync(int id);
}