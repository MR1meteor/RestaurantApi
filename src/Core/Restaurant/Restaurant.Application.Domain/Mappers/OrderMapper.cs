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

    public static DbOrder MapToDb(this Order domain)
    {
        return domain == null
            ? new DbOrder()
            : new DbOrder
            {
                Id = domain.Id,
                TableNumber = domain.TableNumber,
                TotalPrice = domain.TotalPrice,
                Status = (short)domain.Status,
                CreatedTime = domain.CreatedTime
            };
    }

    public static List<DbOrder> MapToDb(this IEnumerable<Order> domainEnumerable)
    {
        return domainEnumerable == null ? new List<DbOrder>() : domainEnumerable.Select(MapToDb).ToList();
    }
}