using astronautas.common;
using astronautas.dto;
using astronautas.port;

namespace astronautas.usecase.Users.Auth;

public class LoginUseCase : ILoginUseCase
{
    private readonly IUserService _userService;
    private readonly IKeyEncryptor _keyEncryptor;

    public LoginUseCase(IUserService userService, IKeyEncryptor keyEncryptor)
    {
        _userService = userService;
        _keyEncryptor = keyEncryptor;
    }

    public async Task<(bool, GetUserResult)> IsValidUserAsync(UserLoginDto dto)
    {
        var user = await _userService.LoginByCredentialAsync(dto.User);
        var validate = _keyEncryptor.ValidatePassword(user.Password!, dto.Password);
        return (validate, new GetUserResult(user.Id!, user.Name!, user.Email!));
    }
}
