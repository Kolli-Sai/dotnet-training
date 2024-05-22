namespace LINQ_Demo1.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerAge { get; set; }
        public List<Order> Orders { get; set; }
    }
}
