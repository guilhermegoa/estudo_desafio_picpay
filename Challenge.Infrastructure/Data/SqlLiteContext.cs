using Challenge.Domain.Entities;
using Challenge.Infrastructure.Data.EntityConfiguration;
using Challenge.Infrastructure.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Infrastructure.Data;

public class SqlLiteContext: DbContext
{
    public SqlLiteContext(DbContextOptions<SqlLiteContext> options): base(options) {}

    public DbSet<User> User { get; set; }
    public DbSet<Transaction> Transaction { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionEntityConfiguration());
        
        modelBuilder.SeedUsers();
        
        base.OnModelCreating(modelBuilder);
    }
}