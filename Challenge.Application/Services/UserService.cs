using Challenge.Domain.Abstractions;
using Challenge.Domain.Entities;

namespace Challenge.Application.Services;

public sealed class UserService : IUserService
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

    public async Task<ResponseUserDTO> AddUser(RequestUserDTO requestUserDTO)
    {
        var toCreate = requestUserDTO.ToEntity();

        var user = await _userRepository.AddUser(toCreate);

        return user.ToDTO();
    }

    public async Task<ResponseUserDTO> UpdateUser(RequestUpdateUserDTO requestUpdateUserDTO)
    {
        var user = await _userRepository.UpdateUser(
            requestUpdateUserDTO.Id,
            requestUpdateUserDTO.Name,
            requestUpdateUserDTO.Email
        );

        return user.ToDTO();
    }

    public async Task DeleteUser(int personId)
    {
        await _userRepository.DeleteUser(personId);
    }
}