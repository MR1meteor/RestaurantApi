using Restaurant.Application.Domain.Postgres;
using Restaurant.Common.DependencyInjection.Interfaces;

namespace Restaurant.Application.Abstractions.Postgres;

public interface IDishRepository : ITransient
{
    Task<List<DbDish>> GetAllAsync();
    Task<DbDish?> GetByIdAsync(int id);
    Task CreateAsync(DbDish dish);
    Task UpdateAsync(DbDish dish);
    Task DeleteByIdAsync(int id);
}