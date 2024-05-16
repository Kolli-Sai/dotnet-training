namespace DependencyInjectionPractice;

public interface IEmployee
{
    public List<Employee> SelectAllEmployees();
}
internal class ConstructorEmployeeDAL : IEmployee
{
    public List<Employee> SelectAllEmployees()
    {
        List<Employee> ListEmployees = new List<Employee>
            {
                //Get the Employees from the Database
                //for now we are hard coded the employees
                new Employee() { ID = 1, Name = "Pranaya", Department = "IT" },
                new Employee() { ID = 2, Name = "Kumar", Department = "HR" },
                new Employee() { ID = 3, Name = "Rout", Department = "Payroll" }
            };
        return ListEmployees;
    }
}
