using Restaurant.Application.Domain.Enums;

namespace Restaurant.Application.Domain.Domain;

public class Order
{
    public int Id { get; set; }
    public int TableNumber { get; set; }
    public float TotalPrice { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime CreatedTime { get; set; }
}