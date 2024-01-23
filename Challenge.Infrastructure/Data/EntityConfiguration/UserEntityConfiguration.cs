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
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        entityTypeBuilder
            .Property(u => u.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(100);

        entityTypeBuilder
            .Property(u => u.Document)
            .HasColumnName("document")
            .IsRequired()
            .HasMaxLength(20);

        entityTypeBuilder
            .HasIndex(u => u.Document)
            .IsUnique();

        entityTypeBuilder
            .Property(u => u.Email)
            .HasColumnName("email")
            .IsRequired()
            .HasMaxLength(255);
            
        entityTypeBuilder
            .HasIndex(u=> u.Email )
            .IsUnique();
        
        entityTypeBuilder
            .Property(u => u.Password)
            .HasColumnName("password")
            .IsRequired();

        entityTypeBuilder
            .Property(u => u.Balance)
            .HasColumnName("balance")
            .IsRequired();

        entityTypeBuilder
            .Property(u => u.UserType)
            .HasColumnName("user_type")
            .IsRequired();
        
        entityTypeBuilder
            .Property(u => u.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("DATE('now')");

        entityTypeBuilder
            .Property(u => u.UpdatedAt)
            .HasColumnName("updated_at")
            .HasDefaultValueSql("DATE('now')")
            .ValueGeneratedOnAddOrUpdate();
    }
}