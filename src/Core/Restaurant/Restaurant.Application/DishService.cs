using Microsoft.Extensions.Logging;
using Restaurant.Application.Abstractions;
using Restaurant.Application.Abstractions.Mongo;
using Restaurant.Application.Domain.Domain;
using Restaurant.Application.Domain.Errors;
using Restaurant.Application.Domain.Mappers;

namespace Restaurant.Application;

public class DishService : IDishService
{
    private readonly IDishRepository _dishRepository;
    private readonly IDishCacheService _dishCacheService;
    private readonly ILogger<DishService> _logger;

    public DishService(IDishRepository dishRepository, IDishCacheService dishCacheService, ILogger<DishService> logger)
    {
        _dishRepository = dishRepository;
        _dishCacheService = dishCacheService;
        _logger = logger;
    }

    public async Task<Result<List<Dish>>> GetAllAsync()
    {
        var cachedData = await _dishCacheService.GetAllAsync();

        if (cachedData.Count != 0)
        {
            _logger.LogInformation("Get all from cache");
            return Result<List<Dish>>.Success(cachedData);
        }
        
        _logger.LogInformation("Get all from db");
        var dishes = await _dishRepository.GetAllAsync();
        await _dishCacheService.AddAllAsync(dishes.MapToDomain());
        return Result<List<Dish>>.Success(dishes.MapToDomain());
    }

    public async Task<Result<Dish>> GetByIdAsync(string id)
    {
        var cachedData = await _dishCacheService.GetByIdAsync(id);

        if (cachedData != null)
        {
            _logger.LogInformation($"Get by id {id} from cache");
            return Result<Dish>.Success(cachedData);
        }
        
        _logger.LogInformation($"Get by id {id} from db");
        var dbDish = await _dishRepository.GetByIdAsync(id);
        if (dbDish == null)
        {
            return Result<Dish>.Failure(Errors.General.ObjectNotFound("Dish"));
        }

        var dish = dbDish.MapToDomain();
        await _dishCacheService.AddAsync(dish);
        return Result<Dish>.Success(dish);
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
        await _dishCacheService.AddAsync(dish);
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