using Cookie.Domain.Entities;
using Cookie.Domain.Interfaces;

namespace Cookie.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{
    public Task<User> AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserById(int id)
    {
        throw new NotImplementedException();
    }
}