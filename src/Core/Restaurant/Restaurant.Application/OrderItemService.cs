using Restaurant.Application.Abstractions;
using Restaurant.Application.Domain.Domain;
using Restaurant.Application.Domain.Mappers;

namespace Restaurant.Application;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;
    
    public async Task<List<OrderItem>> GetAllAsync()
    {
        var orderItems = await _orderItemRepository.GetAllAsync();
        return orderItems.MapToDomain();
    }

    public async Task<OrderItem?> GetByIdAsync(int id)
    {
        var orderItem = await _orderItemRepository.GetByIdAsync(id);
        return orderItem.MapToDomain();
    }

    public async Task CreateAsync(OrderItem orderItem)
    {
        await _orderItemRepository.CreateAsync(orderItem.MapToDb());
    }

    public async Task UpdateAsync(OrderItem orderItem)
    {
        await _orderItemRepository.UpdateAsync(orderItem.MapToDb());
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _orderItemRepository.DeleteByIdAsync(id);
    }
}