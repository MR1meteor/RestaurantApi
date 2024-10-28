using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Restaurant.Application.Abstractions.Mongo;
using Restaurant.Application.Domain.Mongo;

namespace Restaurant.Mongo.Infrastructure;

public class DishRepository : IDishRepository
{
    private readonly IMongoCollection<DbDish> _mongoCollection;

    public DishRepository(IConfiguration configuration)
    {
        var connectionString = configuration["Connections:Mongo"] ??
                               throw new ArgumentException("Set database connection string");
        var mongoClient = new MongoClient(connectionString);
        _mongoCollection = mongoClient.GetDatabase("production").GetCollection<DbDish>("dishes");
    }

    public async Task<List<DbDish>> GetAllAsync()
    {
        var filter = Builders<DbDish>.Filter.Empty;
        var dishes = await _mongoCollection.Find(filter).ToListAsync();
        return dishes;
    }

    public async Task<DbDish?> GetByIdAsync(string id)
    {
        var filter = Builders<DbDish>.Filter.Eq(dish => dish.Id, Guid.Parse(id));
        var dish = await _mongoCollection.Find(filter).FirstOrDefaultAsync();
        return dish;
    }

    public async Task DeleteByIdAsync(string id)
    {
        var filter = Builders<DbDish>.Filter.Eq(dish => dish.Id, Guid.Parse(id));
        await _mongoCollection.DeleteOneAsync(filter);
    }

    public async Task UpdateAsync(DbDish updatedDish)
    {
        var filter = Builders<DbDish>.Filter.Eq(dish => dish.Id, updatedDish.Id);
        await _mongoCollection.ReplaceOneAsync(filter, updatedDish);
    }

    public async Task CreateAsync(DbDish dish)
    {
        dish.Id = Guid.NewGuid();
        await _mongoCollection.InsertOneAsync(dish);
    }
}