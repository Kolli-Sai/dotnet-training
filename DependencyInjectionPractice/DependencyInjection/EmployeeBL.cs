namespace DependencyInjectionPractice;

//That means it is going to be the Dependency Object
public class EmployeeBL
{
    public EmployeeDAL employeeDAL;
    public List<Employee> GetAllEmployees()
    {
        //Creating an Instance of Dependency Class means it is a Tight Coupling
        employeeDAL = new EmployeeDAL();
        return employeeDAL.SelectAllEmployees();
    }
}