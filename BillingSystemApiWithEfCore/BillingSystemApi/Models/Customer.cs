using System.Text.Json.Serialization;

namespace BillingSystemApi.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        
        public List<Transaction> Transactions { get; set; }
    }
}
