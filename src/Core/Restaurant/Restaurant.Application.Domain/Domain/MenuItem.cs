namespace Restaurant.Application.Domain.Domain;

public class MenuItem
{
    public int Id { get; set; }
    public int MenuId { get; set; }
    public int DishId { get; set; }
    public float Price { get; set; }
}