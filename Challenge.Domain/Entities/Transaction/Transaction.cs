namespace Challenge.Domain.Entities;

public class Transaction: BaseEntity
{
    public int Id { get; set; }
    
    public double Amount { get; set; }

    public int SenderId { get; set; }
    
    public User Sender { get; set; }

    public int ReceiverId { get; set; }
    public User Receiver { get; set; }
}