using Challenge.Domain.Abstractions;
using Challenge.Domain.Entities;

namespace Challenge.Application.Services;

public sealed class UserService: IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUserById(int userId)
    {
        return await _userRepository.GetUserById(userId);
    }
    
    public async Task<User> GetUserByDocument(string userDocument)
    {
        return await _userRepository.GetUserByDocument(userDocument);
    }

    public Task<User> AddUser(User toCreate)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUser(int personId, string name, string email)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser(int personId)
    {
        throw new NotImplementedException();
    }
}