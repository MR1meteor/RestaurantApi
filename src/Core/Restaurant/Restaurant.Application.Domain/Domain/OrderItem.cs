using Restaurant.Application.Domain.Enums;

namespace Restaurant.Application.Domain.Domain;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int DishId { get; set; }
    public OrderItemStatus Status { get; set; }
    public float Price { get; set; }
}