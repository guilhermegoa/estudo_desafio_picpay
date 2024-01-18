using Challenge.Domain.Entities;

namespace Challenge.Domain.Abstractions;

public interface IUserRepository
{
    Task<User> GetUserById(int userId);
    
    Task<User> GetUserByDocument(string userDocument);
    
    Task<User> AddUser(User toCreate);

    Task<User> UpdateUser(int userId, string name, string email);

    Task DeleteUser(int userId);
}