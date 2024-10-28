using Restaurant.Application.Domain.Domain;
using Restaurant.Application.Domain.Postgres;

namespace Restaurant.Application.Domain.Mappers;

public static class DishMapper
{
    public static Dish MapToDomain(this DbDish db)
    {
        return db == null
            ? new Dish()
            : new Dish
            {
                Id = db.Id.ToString(),
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

    public static DbDish MapToPostgresDb(this Dish domain)
    {
        return domain == null
            ? new DbDish()
            : new DbDish
            {
                Id = int.TryParse(domain.Id, out var parsedId) ? parsedId : 0,
                Name = domain.Name,
                Description = domain.Description,
                Category = domain.Category,
                IsAvailable = domain.IsAvailable
            };
    }

    public static List<DbDish> MapToPostgresDb(this IEnumerable<Dish> domain)
    {
        return domain == null
            ? new List<DbDish>()
            : domain.Select(MapToPostgresDb).ToList();
    }

    public static Dish MapToDomain(this Mongo.DbDish db)
    {
        return db == null
            ? new Dish()
            : new Dish
            {
                Id = db.Id.ToString(),
                Name = db.Name,
                Description = db.Description,
                Category = db.Category,
                IsAvailable = db.IsAvailable
            };
    }

    public static List<Dish> MapToDomain(this IEnumerable<Mongo.DbDish> db)
    {
        return db == null
            ? new List<Dish>()
            : db.Select(MapToDomain).ToList();
    }

    public static Mongo.DbDish MapToMongoDb(this Dish domain)
    {
        return domain == null
            ? new Mongo.DbDish()
            : new Mongo.DbDish
            {
                Id = Guid.TryParse(domain.Id, out var parsedId) ? parsedId : Guid.Empty,
                Name = domain.Name,
                Description = domain.Description,
                Category = domain.Category,
                IsAvailable = domain.IsAvailable
            };
    }

    public static List<Mongo.DbDish> MapToMongoDb(this IEnumerable<Dish> domain)
    {
        return domain == null
            ? new List<Mongo.DbDish>()
            : domain.Select(MapToMongoDb).ToList();
    }
}