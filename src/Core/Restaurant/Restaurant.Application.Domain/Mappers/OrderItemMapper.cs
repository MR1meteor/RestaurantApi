using Restaurant.Application.Domain.Domain;
using Restaurant.Application.Domain.Enums;
using Restaurant.Application.Domain.Postgres;

namespace Restaurant.Application.Domain.Mappers;

public static class OrderItemMapper
{
    public static OrderItem MapToDomain(this DbOrderItem db)
    {
        return db == null
            ? new OrderItem()
            : new OrderItem
            {
                Id = db.Id,
                OrderId = db.OrderId,
                DishId = db.DishId,
                Status = (OrderItemStatus)db.Status,
                Price = db.Price
            };
    }

    public static List<OrderItem> MapToDomain(this IEnumerable<DbOrderItem> dbEnumerable)
    {
        return dbEnumerable == null ? new List<OrderItem>() : dbEnumerable.Select(MapToDomain).ToList();
    }

    public static DbOrderItem MapToDb(this OrderItem domain)
    {
        return domain == null
            ? new DbOrderItem()
            : new DbOrderItem
            {
                Id = domain.Id,
                OrderId = domain.OrderId,
                DishId = domain.DishId,
                Status = (short)domain.Status,
                Price = domain.Price
            };
    }

    public static List<DbOrderItem> MapToDb(this IEnumerable<OrderItem> domainEnumerable)
    {
        return domainEnumerable == null ? new List<DbOrderItem>() : domainEnumerable.Select(MapToDb).ToList();
    }
}