namespace Restaurant.Application.Domain.Domain;

public class OrderFull : Order
{
    public List<Dish> Dishes { get; set; } = new List<Dish>();
}