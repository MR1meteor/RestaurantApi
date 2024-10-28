namespace Restaurant.Application.Domain.Postgres;

public class DbOrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int DishId { get; set; }
    public short Status { get; set; }
    public float Price { get; set; }
}