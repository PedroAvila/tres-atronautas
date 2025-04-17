using astronautas.port;
using MongoDB.Driver;

namespace astronautas.adapter;

public class MongoRepository<T> : IMongoRepository<T>
    where T : class
{
    protected readonly IMongoCollection<T> _collection;

    public MongoRepository(IMongoDatabase database)
    {
        var collectionName = typeof(T).Name.ToLower() + "s";
        _collection = database.GetCollection<T>(collectionName);
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _collection.InsertOneAsync(entity);
        return entity;
    }

    public async Task DeleteAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        await _collection.DeleteOneAsync(filter);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<T> GetByIdAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(string id, T entity)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        await _collection.ReplaceOneAsync(filter, entity);
    }
}
