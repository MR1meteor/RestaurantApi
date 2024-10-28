using Microsoft.Extensions.Caching.Distributed;
using Restaurant.Application.Abstractions.Redis;

namespace Restaurant.Redis.Infrastructure;

public class RedisClient : IRedisClient
{
    private readonly IDistributedCache _cache;

    public RedisClient(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<byte[]?> GetByKeyAsync(string key)
    {
        return await _cache.GetAsync(key);
    }

    public async Task AddByKeyAsync(string key, byte[] data)
    {
        var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(2));
        await _cache.SetAsync(key, data, options);
    }

    public async Task RemoveByKeyAsync(string key)
    {
        await _cache.RemoveAsync(key);
    }
}