using Restaurant.Application.Domain.Domain;
using Restaurant.Common.DependencyInjection.Interfaces;

namespace Restaurant.Application.Abstractions;

public interface IDishCacheService : ITransient
{
    Task<List<Dish>> GetAllAsync();
    Task<Dish> GetByIdAsync(string id);
    Task AddAllAsync(IEnumerable<Dish> dishes);
    Task AddAsync(Dish dish);
}