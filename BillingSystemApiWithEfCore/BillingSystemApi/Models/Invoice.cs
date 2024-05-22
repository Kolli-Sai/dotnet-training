namespace BillingSystemApi.Models
{
    public class Invoice
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int TransactionId { get; set; }
        public string TransactionFor { get; set; }
        public decimal TransactionsAmount { get; set; }
        public bool IsTransactionSuccessfull { get; set; }
        public DateTime TransactionDateTime { get; set; }
    }
}
