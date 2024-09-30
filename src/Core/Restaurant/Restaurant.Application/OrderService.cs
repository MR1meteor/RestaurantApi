using Restaurant.Application.Abstractions;

namespace Restaurant.Application;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
}