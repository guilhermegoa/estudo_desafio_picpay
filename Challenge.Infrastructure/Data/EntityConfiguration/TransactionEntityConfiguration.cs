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
            .Property(t => t.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        entityTypeBuilder
            .Property(t => t.Amount)
            .HasColumnName("amount")
            .IsRequired();

        entityTypeBuilder
            .Property(t => t.SenderId)
            .HasColumnName("sender_id");
        
        entityTypeBuilder
            .Property(t => t.ReceiverId)
            .HasColumnName("receiver_id");

        entityTypeBuilder
            .Property(u => u.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("DATE('now')");

        entityTypeBuilder
            .Property(u => u.UpdatedAt)
            .HasColumnName("updated_at")
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