using System.Security.Cryptography;
using System.Text;

namespace astronautas.common;

public class KeyEncryptor : IKeyEncryptor
{
    public string HashPassword(string password)
    {
        using var sha = SHA256.Create();
        var asBytes = Encoding.Default.GetBytes(password);
        var hashed = sha.ComputeHash(asBytes);
        return Convert.ToBase64String(hashed);
    }

    public bool ValidatePassword(string passwordRecovered, string passwordEntered)
    {
        return HashPassword(passwordEntered).Equals(passwordRecovered);
    }
}
