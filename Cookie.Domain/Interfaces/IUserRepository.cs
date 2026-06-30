using Cookie.Domain.Entities;
using Cookie.Domain.Pagination;

namespace Cookie.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> AddAsync(User user);
    Task<bool> ExistsAsync();
    Task<bool> UpdateUser(User user);
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetUserById(int id);
}