using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SchoolManager.Domain.Interface.Utils;

public class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        byte[] salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        string result = $"{Convert.ToBase64String(salt)}:{hashed}";

        if (result.Length > 60)
        {
            result = result.Substring(0, 60);
        }

        return result;
    }

    public bool VerifyPassword(string hashedPassword, string password)
    {
        var parts = hashedPassword.Split(':');
        var salt = Convert.FromBase64String(parts[0]);

        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        string result = $"{Convert.ToBase64String(salt)}:{hashed}";
        
        if (result.Length > 60)
        {
            result = result.Substring(0, 60);
        }

        return result == hashedPassword;
    }
}