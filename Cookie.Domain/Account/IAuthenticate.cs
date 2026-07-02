using Cookie.Domain.Entities;
using Cookie.Domain.Enum;

namespace Cookie.Domain.Account;

public interface IAuthenticate
{
    string GenerateToken(int userId, string email, Permission permission);
    Task<User> GetUserByEmail(string email);
    
    Task<bool> Authenticate(string email, string password);
}