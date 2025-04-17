using astronautas.entity;
using astronautas.port;
using MongoDB.Driver;

namespace astronautas.adapter;

public class UserRepository : MongoRepository<User>, IUserRepository
{
    public UserRepository(IMongoDatabase database)
        : base(database) { }

    public Task<User> GetUserByUserAsync(string name)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Name, name);
        return _collection.Find(filter).FirstOrDefaultAsync();
    }
}
