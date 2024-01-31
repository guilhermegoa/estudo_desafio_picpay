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
        return await _context.User.FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<User> GetUserByDocument(string userDocument)
    {
        return await _context.User.FirstOrDefaultAsync(u => u.Document == userDocument);
    }

    public async Task<User> AddUser(User toCreate)
    {
        _context.User.Add(toCreate);

        await _context.SaveChangesAsync();

        return toCreate;
    }

    public Task<User> UpdateUser(int userId, string name, string email)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteUser(int userId)
    {
        await _context.Database.ExecuteSqlRawAsync("DELETE FROM User WHERE Id = {0}", userId);
    }
}