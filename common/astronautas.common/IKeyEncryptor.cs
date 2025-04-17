using System;

namespace astronautas.common;

public interface IKeyEncryptor
{
    string HashPassword(string password);
    bool ValidatePassword(string passwordRecovered, string passwordEntered);
}
