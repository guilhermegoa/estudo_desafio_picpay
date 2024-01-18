using Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenge.Infrastructure.Data.EntityConfiguration;

public class UserEntityConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entityTypeBuilder)
    {
        entityTypeBuilder
            .ToTable("user");

        entityTypeBuilder
            .HasKey(u => u.Id);
        
        entityTypeBuilder
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();

        entityTypeBuilder
            .Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);

        entityTypeBuilder
            .Property(u => u.Document)
            .IsRequired()
            .HasMaxLength(20);

        entityTypeBuilder
            .HasIndex(u => u.Document)
            .IsUnique();

        entityTypeBuilder
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);
            
        entityTypeBuilder
            .HasIndex(u=> u.Email )
            .IsUnique();
        
        entityTypeBuilder
            .Property(u => u.Password)
            .IsRequired();

        entityTypeBuilder
            .Property(u => u.Balance)
            .IsRequired();

        entityTypeBuilder
            .Property(u => u.UserType)
            .IsRequired();
        
        entityTypeBuilder
            .Property(u => u.CreatedAt)
            .HasDefaultValueSql("DATE('now')");

        entityTypeBuilder
            .Property(u => u.UpdatedAt)
            .HasDefaultValueSql("DATE('now')")
            .ValueGeneratedOnAddOrUpdate();
    }
}