namespace BillingSystem;



public class Transaction
{
    public string TransactionId { get; set; } = null!;
    public TransactionTypes TransactionTypes { get; set; }
    public decimal TransactionAmount { get; set; }
    public DateOnly TransactionDate { get; set; }
    public bool IsTransactionSuccessfull { get; set; }
    public string CustomerId { get; set; } = null!;
    public string CustomerName { get; set; } = null!;
}