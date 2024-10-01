using Restaurant.Application.Domain.Domain;
using Restaurant.Application.Domain.PostgresDb;

namespace Restaurant.Application.Domain.Mappers;

public static class DishMapper
{
    public static Dish MapToDomain(this DbDish db)
    {
        return db == null
            ? new Dish()
            : new Dish
            {
                Id = db.Id,
                Name = db.Name,
                Description = db.Description,
                Category = db.Category,
                IsAvailable = db.IsAvailable
            };
    }

    public static List<Dish> MapToDomain(this IEnumerable<DbDish> db)
    {
        return db == null
            ? new List<Dish>()
            : db.Select(MapToDomain).ToList();
    }
    
    public static DbDish MapToDb(this Dish domain)
    {
        return domain == null
            ? new DbDish()
            : new DbDish
            {
                Id = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
                Category = domain.Category,
                IsAvailable = domain.IsAvailable
            };
    }
    
    public static List<DbDish> MapToDb(this IEnumerable<Dish> domain)
    {
        return domain == null
            ? new List<DbDish>()
            : domain.Select(MapToDb).ToList();
    }
}