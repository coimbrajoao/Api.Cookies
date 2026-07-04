using Cookie.Domain.Entities;

namespace Cookie.Domain.Interfaces;

public interface IPasswordHasher
{
    Task<(byte[] PasswordSalt, byte[] PasswordHash)> GeneatePasswordHash(string password);
    Task<bool> VerifyPasswordHash(string password, byte[]passwordSalt, byte[] passwordHash);
}