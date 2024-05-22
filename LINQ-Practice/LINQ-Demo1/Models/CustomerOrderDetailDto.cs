namespace LINQ_Demo1.Models
{
    public class CustomerOrderDetailDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int OrderAmount { get; set; }
    }
}
