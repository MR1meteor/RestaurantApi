using System.Text;
using System.Text.Json;
using Restaurant.Application.Abstractions;
using Restaurant.Application.Abstractions.Redis;
using Restaurant.Application.Domain.Domain;

namespace Restaurant.Application;

public class DishCacheService : IDishCacheService
{
    private const string GET_ALL_KEY = "GET_ALL_DISHES";
    private const string GET_SINGLE_KEY = "Dish_";

    private readonly IRedisClient _redisClient;

    public DishCacheService(IRedisClient redisClient)
    {
        _redisClient = redisClient;
    }

    public async Task<List<Dish>> GetAllAsync()
    {
        var cachedDishBytes = await _redisClient.GetByKeyAsync(GET_ALL_KEY);

        if (cachedDishBytes == null) return new List<Dish>();

        return ConvertCacheToData<List<Dish>>(cachedDishBytes);
    }

    public async Task<Dish> GetByIdAsync(string id)
    {
        var key = $"{GET_SINGLE_KEY}{id}";
        var cachedDishBytes = await _redisClient.GetByKeyAsync(key);

        if (cachedDishBytes == null) return null;

        return ConvertCacheToData<Dish>(cachedDishBytes);
    }

    public async Task AddAllAsync(IEnumerable<Dish> dishes)
    {
        var cachedDishesBytes = ConvertDataToCache(dishes);
        await _redisClient.AddByKeyAsync(GET_ALL_KEY, cachedDishesBytes);
    }

    public async Task AddAsync(Dish dish)
    {
        var key = $"{GET_SINGLE_KEY}{dish.Id}";
        var cachedDishBytes = ConvertDataToCache(dish);
        await _redisClient.AddByKeyAsync(key, cachedDishBytes);
    }

    private static T ConvertCacheToData<T>(byte[]? bytes)
    {
        if (bytes == null) return default;

        var stringBytes = Encoding.UTF8.GetString(bytes);
        var deserializedData = JsonSerializer.Deserialize<T>(stringBytes) ?? default;

        return deserializedData;
    }

    private static byte[] ConvertDataToCache<T>(T data)
    {
        var serializedData = JsonSerializer.Serialize(data);
        return Encoding.UTF8.GetBytes(serializedData);
    }
}