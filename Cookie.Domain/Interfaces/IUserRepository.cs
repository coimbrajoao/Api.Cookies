using Cookie.Domain.Entities;

namespace Cookie.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> AddUser(User user);
    Task<User> UpdateUser(User user);
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetUserById(int id);
}