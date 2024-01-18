using Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Infrastructure.Data.Seed;

public static class UserDbInitializer
{
    public static void SeedUsers(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Name = "Usuário 1",
                Document = "123456789",
                Email = "usuario1@example.com",
                Password = "senha1",
                Balance = 1000.0,
                UserType = UserType.Common
            },
            new User
            {
                Id = 2,
                Name = "Usuário 2",
                Document = "987654321",
                Email = "usuario2@example.com",
                Password = "senha2",
                Balance = 500.0,
                UserType = UserType.Merchant
            }
        );
    }
}