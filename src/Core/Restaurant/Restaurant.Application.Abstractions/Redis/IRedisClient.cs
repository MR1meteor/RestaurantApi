using Restaurant.Common.DependencyInjection.Interfaces;

namespace Restaurant.Application.Abstractions.Redis;

public interface IRedisClient : ITransient
{
    Task<byte[]?> GetByKeyAsync(string key);
    Task AddByKeyAsync(string key, byte[] data);
    Task RemoveByKeyAsync(string key);
}