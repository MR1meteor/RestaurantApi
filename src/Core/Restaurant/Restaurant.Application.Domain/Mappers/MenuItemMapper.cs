using Restaurant.Application.Domain.Domain;
using Restaurant.Application.Domain.Postgres;

namespace Restaurant.Application.Domain.Mappers;

public static class MenuItemMapper
{
    public static MenuItem MapToDomain(this DbMenuItem db)
    {
        return db == null
            ? new MenuItem()
            : new MenuItem
            {
                Id = db.Id,
                MenuId = db.MenuId,
                DishId = db.DishId,
                Price = db.Price
            };
    }

    public static List<MenuItem> MapToDomain(this IEnumerable<DbMenuItem> dbEnumerable)
    {
        return dbEnumerable == null ? new List<MenuItem>() : dbEnumerable.Select(MapToDomain).ToList();
    }

    public static DbMenuItem MapToDb(this MenuItem domain)
    {
        return domain == null
            ? new DbMenuItem()
            : new DbMenuItem
            {
                Id = domain.Id,
                MenuId = domain.MenuId,
                DishId = domain.DishId,
                Price = domain.Price
            };
    }

    public static List<DbMenuItem> MapToDb(this IEnumerable<MenuItem> domainEnumerable)
    {
        return domainEnumerable == null ? new List<DbMenuItem>() : domainEnumerable.Select(MapToDb).ToList();
    }
}