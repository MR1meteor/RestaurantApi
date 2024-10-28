namespace Restaurant.Application.Domain.Postgres;

public class DbMenu
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}