using Cookie.Domain.Entities;
using Cookie.Domain.Interfaces;
using Cookie.Domain.Pagination;
using Cookie.Infra.Data.Context;
using Cookie.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Cookie.Infra.Data.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{

    public async  Task<User> AddAsync(User user)
    {
        context.User.Add(user);
        return user;
    }

    public async Task<bool> ExistsAsync()
    {
        return await context.User.AnyAsync();
    }


    public async Task<bool> UpdateUser(User user)
    {
        context.User.Update(user);
        return true;
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