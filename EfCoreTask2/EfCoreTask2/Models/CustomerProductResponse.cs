﻿namespace EfCoreTask2.Models
{
    public class CustomerProductResponse
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<Product> Products { get; set; }
    }
}