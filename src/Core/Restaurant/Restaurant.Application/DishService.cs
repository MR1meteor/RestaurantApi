using Restaurant.Application.Abstractions;
using Restaurant.Application.Abstractions.Mongo;
using Restaurant.Application.Domain.Domain;
using Restaurant.Application.Domain.Errors;
using Restaurant.Application.Domain.Mappers;

namespace Restaurant.Application;

public class DishService : IDishService
{
    private readonly IDishRepository _dishRepository;

    public DishService(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }

    public async Task<Result<List<Dish>>> GetAllAsync()
    {
        var dishes = await _dishRepository.GetAllAsync();
        return Result<List<Dish>>.Success(dishes.MapToDomain());
    }

    public async Task<Result<Dish>> GetByIdAsync(string id)
    {
        var dish = await _dishRepository.GetByIdAsync(id);
        return dish == null
            ? Result<Dish>.Failure(Errors.General.ObjectNotFound("Dish"))
            : Result<Dish>.Success(dish.MapToDomain());
    }

    public async Task<Result> CreateAsync(Dish dish)
    {
        await _dishRepository.CreateAsync(dish.MapToMongoDb());
        return Result.Success();
    }

    public async Task<Result> UpdateAsync(Dish dish)
    {
        var dbDish = await _dishRepository.GetByIdAsync(dish.Id);
        if (dbDish == null)
        {
            return Result.Failure(Errors.General.ObjectNotFound("Dish"));
        }
        
        await _dishRepository.UpdateAsync(dish.MapToMongoDb());
        return Result.Success();
    }

    public async Task<Result> DeleteByIdAsync(string id)
    {
        var dbDish = await _dishRepository.GetByIdAsync(id);
        if (dbDish == null)
        {
            return Result.Failure(Errors.General.ObjectNotFound("Dish"));
        }
        
        await _dishRepository.DeleteByIdAsync(id);
        return Result.Success();
    }
}