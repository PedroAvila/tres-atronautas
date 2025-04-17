using astronautas.entity;

namespace astronautas.port;

public interface IUserService
{
    Task<User> LoginByCredentialAsync(string name);
}
