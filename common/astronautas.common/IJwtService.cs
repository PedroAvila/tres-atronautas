using System;

namespace astronautas.common;

public interface IJwtService
{
    string GenerateToken(string userId);
}
