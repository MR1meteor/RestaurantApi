using Restaurant.Application.Abstractions;
using Restaurant.Application.Domain.Domain;
using Restaurant.Application.Domain.Mappers;

namespace Restaurant.Application;

public class DishService : IDishService
{
    private readonly IDishRepository _dishRepository;

    public DishService(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }

    public async Task<List<Dish>> GetAllAsync()
    {
        var dishes = await _dishRepository.GetAllAsync();
        return dishes.MapToDomain();
    }

    public async Task<Dish?> GetByIdAsync(int id)
    {
        var dish = await _dishRepository.GetByIdAsync(id);
        return dish.MapToDomain();
    }

    public async Task CreateAsync(Dish dish)
    {
        await _dishRepository.CreateAsync(dish.MapToDb());
    }

    public async Task UpdateAsync(Dish dish)
    {
        await _dishRepository.UpdateAsync(dish.MapToDb());
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _dishRepository.DeleteByIdAsync(id);
    }
}