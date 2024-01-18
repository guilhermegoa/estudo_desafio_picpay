using Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenge.Infrastructure.Data.EntityConfiguration;

public class TransactionEntityConfiguration: IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> entityTypeBuilder)
    {
        entityTypeBuilder
            .ToTable("transaction");

        entityTypeBuilder
            .HasKey(t => t.Id);
        
        entityTypeBuilder
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();
        
        entityTypeBuilder
            .Property(t => t.Id)
            .ValueGeneratedOnAdd();

        entityTypeBuilder
            .Property(t => t.Amount)
            .IsRequired();

        entityTypeBuilder
            .Property(u => u.CreatedAt)
            .HasDefaultValueSql("DATE('now')");

        entityTypeBuilder
            .Property(u => u.UpdatedAt)
            .HasDefaultValueSql("DATE('now')")
            .ValueGeneratedOnAddOrUpdate();
        
        entityTypeBuilder
            .HasOne(t => t.Sender)
            .WithMany(u => u.SentTransactions) 
            .HasForeignKey(t => t.SenderId)
            .IsRequired();
        
        entityTypeBuilder
            .HasOne(t => t.Receiver)
            .WithMany()
            .HasForeignKey(t => t.ReceiverId)
            .IsRequired();
    }
}