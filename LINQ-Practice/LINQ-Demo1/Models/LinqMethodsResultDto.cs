namespace LINQ_Demo1.Models
{
    public class LinqMethodsResultDto
    {
        public bool AllMethodResult { get; set; }
        public bool AnyMethodResult { get; set; }
        public IEnumerable<Customer> AppendMethodResult { get; set; }
        public double AverageMethodResult { get; set; }
        public IEnumerable<Customer> ConcatMethodResult { get; set; }
        public bool ContainsMethodResult { get; set; }
        public int CountMethodResult { get; set; }
        public IEnumerable<Customer> DefaultIfEmptyMethodResult { get; set; }
        public Customer ElementAtMethodResult { get; set; }
        public Customer ElementAtOrDefaultMethodResult { get; set; }
        public Customer FirstMethodResult { get; set; }
        public Customer FirstOrDefaultMethodResult { get; set; }
        public IEnumerable<CustomerOrderTotalDto> GroupByMethodResult { get; set; }
        public IEnumerable<CustomerOrderDetailDto> JoinMethodResult { get; set; }
        public Customer LastMethodResult { get; set; }
        public Customer LastOrDefaultMethodResult { get; set; }
        public int MaxByMethodResult { get; set; }
        public int MinByMethodResult { get; set; }
        public IEnumerable<Customer> OrderByDescendingMethodResult { get; set; }
        public IEnumerable<Customer> OrderByMethodResult { get; set; }
        public IEnumerable<Customer> PrependMethodResult { get; set; }
        public IEnumerable<Customer> ReverseMethodResult { get; set; }
        public IEnumerable<Order> SelectManyMethodResult { get; set; }
        public IEnumerable<CustomerDTO> SelectMethodResult { get; set; }
        public IEnumerable<Customer> SkipLastMethodResult { get; set; }
        public IEnumerable<Customer> SkipMethodResult { get; set; }
        public int SumMethodResult { get; set; }
        public IEnumerable<Customer> TakeLastMethodResult { get; set; }
        public IEnumerable<Customer> TakeMethodResult { get; set; }
        public IEnumerable<Customer> ToListMethodResult { get; set; }
        public IEnumerable<Customer> WhereMethodResult { get; set; }
    }

}
