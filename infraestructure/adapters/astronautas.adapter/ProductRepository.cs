using astronautas.entity;
using astronautas.port;
using MongoDB.Driver;

namespace astronautas.adapter;

public class ProductRepository : MongoRepository<Product>, IProductRepository
{
    public ProductRepository(IMongoDatabase database)
        : base(database) { }
}
