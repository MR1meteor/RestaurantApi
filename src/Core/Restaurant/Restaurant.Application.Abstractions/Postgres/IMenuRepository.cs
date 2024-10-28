using Restaurant.Application.Domain.Postgres;
using Restaurant.Common.DependencyInjection.Interfaces;

namespace Restaurant.Application.Abstractions.Postgres;

public interface IMenuRepository : ITransient
{
    Task<List<DbMenu>> GetAllAsync();
    Task<DbMenu?> GetByIdAsync(int id);
    Task CreateAsync(DbMenu menu);
    Task UpdateAsync(DbMenu menu);
    Task DeleteByIdAsync(int id);
}