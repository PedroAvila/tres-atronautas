using System;

namespace astronautas.usecase.Users;

public record CreateUserDto(string Name, string Email, string Password);
