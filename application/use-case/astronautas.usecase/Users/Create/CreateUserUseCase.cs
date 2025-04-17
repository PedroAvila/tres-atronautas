using astronautas.common;
using astronautas.entity;
using astronautas.port;

namespace astronautas.usecase.Users;

public class CreateUserUseCase : ICreateUserUseCase
{
    private readonly IMongoRepository<User> _userRepository;
    private readonly IKeyEncryptor _keyEncryptor;

    public CreateUserUseCase(IMongoRepository<User> userRepository, IKeyEncryptor keyEncryptor)
    {
        _keyEncryptor = keyEncryptor;
        _userRepository = userRepository;
    }

    public async Task<CreateUserResult> Execute(CreateUserDto dto)
    {
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            Password = _keyEncryptor.HashPassword(dto.Password),
        };

        var newUser = await _userRepository.CreateAsync(user);
        return new CreateUserResult(newUser.Id!, newUser.Name!, newUser.Email!);
    }
}
