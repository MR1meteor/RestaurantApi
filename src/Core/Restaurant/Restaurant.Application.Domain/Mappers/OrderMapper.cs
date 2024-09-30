using Restaurant.Application.Domain.Domain;
using Restaurant.Application.Domain.Enums;
using Restaurant.Application.Domain.PostgresDb;

namespace Restaurant.Application.Domain.Mappers;

public static class OrderMapper
{
    public static Order MapToDomain(this DbOrder? db)
    {
        return db == null
            ? new Order()
            : new Order
            {
                Id = db.Id,
                TableNumber = db.TableNumber,
                TotalPrice = db.TotalPrice,
                Status = (OrderStatus)db.Status,
                CreatedTime = db.CreatedTime
            };
    }
    
    public static List<Order> MapToDomain(this IEnumerable<DbOrder>? db)
    {
        return db == null
            ? new List<Order>()
            : db.Select(MapToDomain).ToList();
    }

    public static OrderFull MapToFullDomain(this DbOrder? db, IEnumerable<DbDish> dbDishes)
    {
        return db == null
            ? new OrderFull()
            : new OrderFull
            {
                Id = db.Id,
                TableNumber = db.TableNumber,
                TotalPrice = db.TotalPrice,
                Status = (OrderStatus)db.Status,
                CreatedTime = db.CreatedTime,
                Dishes = dbDishes.MapToDomain()
            };
    }
}