using Restaurant.Application.Abstractions;
using Restaurant.Application.Abstractions.Postgres;
using Restaurant.Application.Domain.Domain;
using Restaurant.Application.Domain.Mappers;

namespace Restaurant.Application;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<Order>> GetAllAsync()
    {
        var orders = await _orderRepository.GetAllAsync();
        return orders.MapToDomain();
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        return order.MapToDomain();
    }

    public async Task CreateAsync(Order orderItem)
    {
        await _orderRepository.CreateAsync(orderItem.MapToDb());
    }

    public async Task UpdateAsync(Order orderItem)
    {
        await _orderRepository.UpdateAsync(orderItem.MapToDb());
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _orderRepository.DeleteByIdAsync(id);
    }
}