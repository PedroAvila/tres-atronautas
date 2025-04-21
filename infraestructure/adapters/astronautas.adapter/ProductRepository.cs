using astronautas.entity;
using astronautas.port;
using MongoDB.Driver;

namespace astronautas.adapter;

public class ProductRepository : MongoRepository<Product>, IProductRepository
{
    public ProductRepository(IMongoDatabase database)
        : base(database) { }

    public async Task<IEnumerable<Product>> ProductsByUserIdAsync(string userId)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.UserId, userId);
        return await _collection.Find(filter).ToListAsync();
    }
}
