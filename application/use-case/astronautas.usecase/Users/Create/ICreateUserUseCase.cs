namespace astronautas.usecase.Users;

public interface ICreateUserUseCase
{
    Task<CreateUserResult> Execute(CreateUserDto dto);
}
