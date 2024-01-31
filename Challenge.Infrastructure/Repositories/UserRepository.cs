using Challenge.Domain.Abstractions;
using Challenge.Domain.Entities;
using Challenge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SqlLiteContext _context;

    public UserRepository(SqlLiteContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserById(int userId)
    {
        var user = await _context.User.FirstOrDefaultAsync(u => u.Id == userId);

        return user ?? throw new Exception("User not found.");
    }

    public async Task<User> GetUserByDocument(string userDocument)
    {
        var user = await _context.User.FirstOrDefaultAsync(u => u.Document == userDocument);

        return user ?? throw new Exception("User not found.");
    }

    public async Task<User> AddUser(User toCreate)
    {
        _context.User.Add(toCreate);

        await _context.SaveChangesAsync();

        return toCreate;
    }

    public async Task<User> UpdateUser(int userId, string name, string email)
    {
        var user = await _context.User.FirstOrDefaultAsync(u => u.Id == userId);

        if (user is not null)
        {
            user.Name = name;
            user.Email = email;

            await _context.SaveChangesAsync();
        }

        return user ?? throw new Exception("User not found.");
    }

    public async Task DeleteUser(int userId)
    {
        var user = await _context.User.FirstOrDefaultAsync(u => u.Id == userId);

        if (user is not null)
        {
            _context.User.Remove(user);

            await _context.SaveChangesAsync();
        }
    }
}