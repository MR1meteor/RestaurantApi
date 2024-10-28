using Restaurant.Application.Domain.Domain;
using Restaurant.Application.Domain.Errors;
using Restaurant.Common.DependencyInjection.Interfaces;

namespace Restaurant.Application.Abstractions;

public interface IDishService : ITransient
{
    Task<Result<List<Dish>>> GetAllAsync();
    Task<Result<Dish>> GetByIdAsync(string id);
    Task<Result> CreateAsync(Dish dish);
    Task<Result> UpdateAsync(Dish dish);
    Task<Result> DeleteByIdAsync(string id);
}