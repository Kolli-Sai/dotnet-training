using BillingSystemApi.Models;

namespace BillingSystemApi.DTOs
{
    public class CreateTransactionRequest
    {
        public string TransactionFor { get; set; }
        public decimal TransactionsAmount { get; set; }
        public bool IsTransactionSuccessfull { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public int CustomerId { get; set; }
    }
}
