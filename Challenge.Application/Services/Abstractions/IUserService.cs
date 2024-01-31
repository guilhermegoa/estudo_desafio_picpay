using Challenge.Domain.Entities;

namespace Challenge.Application.Services;

public interface IUserService
{
    Task<User> GetUserById(int userId);

    Task<User> GetUserByDocument(string userDocument);

    Task<ResponseUserDTO> AddUser(RequestUserDTO requestUserDTO);

    Task<ResponseUserDTO> UpdateUser(RequestUpdateUserDTO requestUpdateUserDTO);

    Task DeleteUser(int userId);
}