using Challenge.Domain.Entities;

namespace Challenge.Application.Services;

public interface IUserService
{
    Task<User> GetUserById(int userId);

    Task<User> GetUserByDocument(string userDocument);

    Task<ResponseUserDTO> AddUser(RequestUserDTO requestUserDTO);

    Task<ResponseUserDTO> UpdateUser(RequestUserDTO requestUserDTO);

    Task DeleteUser(int userId);
}