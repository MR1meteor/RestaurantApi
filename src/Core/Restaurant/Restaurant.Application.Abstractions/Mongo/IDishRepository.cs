using Restaurant.Application.Domain.Mongo;
using Restaurant.Common.DependencyInjection.Interfaces;

namespace Restaurant.Application.Abstractions.Mongo;

public interface IDishRepository : ITransient
{
    Task<List<DbDish>> GetAllAsync();
    Task<DbDish?> GetByIdAsync(string id);
    Task CreateAsync(DbDish dish);
    Task UpdateAsync(DbDish dish);
    Task DeleteByIdAsync(string id);
}