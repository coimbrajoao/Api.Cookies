using Cookie.Domain.Entities;
using Cookie.Domain.Interfaces;
using Cookie.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Cookie.Infra.Data.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{

    public async Task<User> AddUser(User user)
    {
        await context.User.AddAsync(user);
        return user;
    }

    public async Task<User> UpdateUser(User user)
    {
        context.User.Update(user);
        return user;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await context.User.FirstOrDefaultAsync(u => u.Email == email && u.Active != 0);
    }

    public async Task<User?> GetUserById(int id)
    {
        return await context.User.FirstOrDefaultAsync(u => u.Id == id);
    }
}