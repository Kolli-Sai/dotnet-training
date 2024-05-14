using BillingSystem.Models;

namespace BillingSystem.Services
{
    public interface ICustomerOperations
    {
        void CreateCustomer();
        Customer GetCustomer(int id);
        List<Customer> GetCustomers();

    }
}
