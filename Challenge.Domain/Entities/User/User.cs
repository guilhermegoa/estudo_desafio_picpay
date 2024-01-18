namespace Challenge.Domain.Entities;

public class User: BaseEntity
{
    public int Id { get; set; }
    
    public string Name { get; set; } = String.Empty;
    
    public string Document { get; set; } = String.Empty;
    
    public string Email { get; set; } = String.Empty;
    
    public string Password { get; set; } = String.Empty;
    
    public double Balance { get; set; }
    
    public UserType UserType { get; set; }
    
    public ICollection<Transaction> SentTransactions { get; set; }
}