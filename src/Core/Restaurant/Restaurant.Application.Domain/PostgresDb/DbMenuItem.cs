namespace Restaurant.Application.Domain.PostgresDb;

public class DbMenuItem
{
    public int Id { get; set; }
    public int MenuId { get; set; }
    public int DishId { get; set; }
    public float Price { get; set; }
}