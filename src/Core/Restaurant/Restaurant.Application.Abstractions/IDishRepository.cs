using Restaurant.Application.Domain.PostgresDb;
using Restaurant.Common.DependencyInjection.Interfaces;

namespace Restaurant.Application.Abstractions;

public interface IDishRepository : ITransient
{
    Task<List<DbDish>> GetAllAsync();
    Task<DbDish?> GetByIdAsync(int id);
    Task CreateAsync(DbDish dish);
    Task UpdateAsync(DbDish dish);
    Task DeleteByIdAsync(int id);
}