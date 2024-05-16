using BillingSystem.Enums;

namespace BillingSystem.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public decimal TransactionAmount { get; set; }
        public ETransactionType TransactionType  { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool  IsTransactionSuccessfull { get; set; }
        public int CustomerId { get; set; }
    }
}
