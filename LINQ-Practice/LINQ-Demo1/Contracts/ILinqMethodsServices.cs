using LINQ_Demo1.Models;

namespace LINQ_Demo1.Contracts
{
    public interface ILinqMethodsServices
    {
        // filtering
        Task<IEnumerable<Customer>> WhereMethod();

    

        // partitioning

        Task<IEnumerable<Customer>> SkipMethod();
        Task<IEnumerable<Customer>> TakeMethod();
        Task<IEnumerable<Customer>> SkipLastMethod();
        Task<IEnumerable<Customer>> TakeLastMethod();

        

        // projection
        Task<IEnumerable<CustomerDTO>> SelectMethod();
        Task<IEnumerable<Order>> SelectManyMethod();
            // cast
            // chunk

        // Existence or Quantity checks
        Task<bool> AnyMethod();
        Task<bool> AllMethod();
        Task<bool> ContainsMethod();


        // Sequence manipulation
        Task<IEnumerable<Customer>> AppendMethod();
        Task<IEnumerable<Customer>> PrependMethod();

        // Aggregation methods
        Task<int> CountMethod();
       
        Task<int> SumMethod();
        Task<double> AverageMethod();
        Task<int> MaxByMethod();
        Task<int> MinByMethod();


        // Element Operators
        Task<Customer> FirstMethod();
        Task<Customer> FirstOrDefaultMethod();
        
        //Task<Customer> LastMethod();
        //Task<Customer> LastOrDefaultMethod();
        Task<Customer> ElementAtMethod();
        Task<Customer> ElementAtOrDefaultMethod();
        //Task<IEnumerable<Customer>> DefaultIfEmptyMethod();


        // ConversionMethods
        Task<IEnumerable<Customer>> ToListMethod();

        // Joining and Grouping
        Task<IEnumerable<CustomerOrderDetailDto>> JoinMethod();
        Task<IEnumerable<Customer>> ConcatMethod();
        Task<IEnumerable<CustomerOrderTotalDto>> GroupByMethod();

        // Sorting
        Task<IEnumerable<Customer>> OrderByMethod();
        Task<IEnumerable<Customer>> OrderByDescendingMethod();
        Task<IEnumerable<Customer>> ReverseMethod();



    }
}
