using Restaurant.Application.Domain.Domain;
using Restaurant.Common.DependencyInjection.Interfaces;

namespace Restaurant.Application.Abstractions;

public interface IOrderItemService : ITransient
{
    Task<List<OrderItem>> GetAllAsync();
    Task<OrderItem?> GetByIdAsync(int id);
    Task CreateAsync(OrderItem orderItem);
    Task UpdateAsync(OrderItem orderItem);
    Task DeleteByIdAsync(int id);
}