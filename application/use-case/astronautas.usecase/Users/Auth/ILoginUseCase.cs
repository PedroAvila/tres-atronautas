using astronautas.dto;

namespace astronautas.usecase.Users.Auth;

public interface ILoginUseCase
{
    Task<(bool, GetUserResult)> IsValidUserAsync(UserLoginDto dto);
}
