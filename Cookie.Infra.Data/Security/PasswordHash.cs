using System.Security.Cryptography;
using System.Text;
using Cookie.Domain.Interfaces;

namespace Cookie.Infra.Data.Security;

public class PasswordHash : IPasswordHasher
{
    public async Task<(byte[] PasswordSalt, byte[] PasswordHash)> GeneatePasswordHash(string password)
    {
        using var hmac = new HMACSHA512();
        byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        byte[] passwordSalt = hmac.Key;

        return (passwordSalt, passwordHash);
    }

    public async Task<bool> VerifyPasswordHash(string password, byte[] PasswordSalt, byte[] PasswordHash)
    {
        using var hmac = new HMACSHA512(PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        
        for (int i = 0; i < computedHash.Length; i++)
        {
            if(computedHash[i] != PasswordHash[i])
                return false;
        }
        return true;
    }
}