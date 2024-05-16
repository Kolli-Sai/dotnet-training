namespace DependencyInjectionPractice;

internal class ConstructorEmployeeBL
{
    public IEmployee employeeDAL;
    public ConstructorEmployeeBL(IEmployee employeeDAL)
    {

        this.employeeDAL = employeeDAL;

    }

    public List<Employee> GetAllEmployees()
    {
        return employeeDAL.SelectAllEmployees();
    }
}
