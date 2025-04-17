using astronautas.entity;
using astronautas.port;

namespace astronautas.service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> LoginByCredentialAsync(string name)
    {
        var user = await _userRepository.GetUserByUserAsync(name);
        if (user == null)
            throw new Exception("User not found");

        return user;
    }
}
