using Challenge.Domain.Entities;

namespace Challenge.Application;

public record RequestUserDTO(string Name, string Document, string Email, string Password, double Balance, UserType UserType);
public record ResponseUserDTO(
    int Id,
    string Name,
    string Document,
    string Email,
    string Password,
    double Balance,
    UserType UserType,
    ICollection<Transaction> SentTransactions
);

public record RequestUpdateUserDTO(string Name, string Email, int Id);

public static class UserDTOExtensions
{
    public static User ToEntity(this RequestUserDTO userDTO)
    {
        return new User
        {
            Name = userDTO.Name,
            Document = userDTO.Document,
            Email = userDTO.Email,
            Password = userDTO.Password,
            Balance = userDTO.Balance,
            UserType = userDTO.UserType
        };
    }

    public static ResponseUserDTO ToDTO(this User user)
    {
        return new ResponseUserDTO(
            user.Id,
            user.Name,
            user.Document,
            user.Email,
            user.Password,
            user.Balance,
            user.UserType,
            user.SentTransactions
            );
    }
}

