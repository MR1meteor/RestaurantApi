using System.Runtime.Intrinsics.Arm;
using Restaurant.Application.Domain.Domain;
using Restaurant.Application.Domain.PostgresDb;

namespace Restaurant.Application.Domain.Mappers;

public static class MenuMapper
{
    public static Menu MapToDomain(this DbMenu db)
    {
        return db == null
            ? new Menu()
            : new Menu
            {
                Id = db.Id,
                Title = db.Title,
                Description = db.Description
            };
    }

    public static List<Menu> MapToDomain(this IEnumerable<DbMenu> dbEnumerable)
    {
        return dbEnumerable == null ? new List<Menu>() : dbEnumerable.Select(MapToDomain).ToList();
    }

    public static DbMenu MapToDb(this Menu domain)
    {
        return domain == null
            ? new DbMenu()
            : new DbMenu
            {
                Id = domain.Id,
                Title = domain.Title,
                Description = domain.Description
            };
    }

    public static List<DbMenu> MapToDb(this IEnumerable<Menu> domainEnumerable)
    {
        return domainEnumerable == null ? new List<DbMenu>() : domainEnumerable.Select(MapToDb).ToList();
    }
}