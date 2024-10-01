namespace Restaurant.Application.Domain.PostgresDb;

public class DbOrder
{
    public int Id { get; set; }
    public int TableNumber { get; set; }
    public float TotalPrice { get; set; }
    public short Status { get; set; }
    public DateTime CreatedTime { get; set; }
}