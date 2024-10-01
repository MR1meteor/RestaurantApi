using Restaurant.Application.Domain.Domain;
using Restaurant.Common.DependencyInjection.Interfaces;

namespace Restaurant.Application.Abstractions;

public interface IOrderService : ITransient
{
    Task<List<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task CreateAsync(Order orderItem);
    Task UpdateAsync(Order orderItem);
    Task DeleteByIdAsync(int id);
}