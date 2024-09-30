using Restaurant.Application.Domain.Domain;
using Restaurant.Common.DependencyInjection.Interfaces;

namespace Restaurant.Application.Abstractions;

public interface IDishService : ITransient
{
    Task<List<Dish>> GetAllAsync();
    Task<Dish?> GetByIdAsync(int id);
    Task CreateAsync(Dish dish);
    Task UpdateAsync(Dish dish);
    Task DeleteByIdAsync(int id);
}