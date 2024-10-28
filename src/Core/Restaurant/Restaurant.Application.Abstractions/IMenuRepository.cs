using Restaurant.Application.Domain.PostgresDb;
using Restaurant.Common.DependencyInjection.Interfaces;

namespace Restaurant.Application.Abstractions;

public interface IMenuRepository : ITransient
{
    Task<List<DbMenu>> GetAllAsync();
    Task<DbMenu?> GetByIdAsync(int id);
    Task CreateAsync(DbMenu menu);
    Task UpdateAsync(DbMenu menu);
    Task DeleteByIdAsync(int id);
}