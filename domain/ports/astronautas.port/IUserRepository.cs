using astronautas.entity;

namespace astronautas.port;

public interface IUserRepository : IMongoRepository<User>
{
    Task<User> GetUserByUserAsync(string name);
}
