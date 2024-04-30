using System.Collections;

namespace ArrayListDemo;

public class DoOperations
{
    readonly EmployeeOperations emp = new EmployeeOperations();
    static int CreateId(ArrayList employees)
    {
        return employees.Count + 1;
    }

    public void Add()
    {
        Console.WriteLine("Enter Employee Name : ");
        string empName = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Enter Employee Salary : ");
        decimal empSalary = Convert.ToDecimal(Console.ReadLine());
        Employee employee = new Employee(CreateId(emp.Employees), empName, empSalary);
        if (emp.AddEmployee(employee))
        {
            Console.WriteLine("Added successfully.");
        }
        else
        {
            System.Console.WriteLine("Failed to add.");
        }
    }

    public void Remove()
    {
        Console.WriteLine("Enter Employee Id : ");
        int empId = Convert.ToInt32(Console.ReadLine());
        if (emp.RemoveEmployee(empId))
        {
            Console.WriteLine("Removed successfully.");
        }
        else
        {
            Console.WriteLine("Failed to Remove");
        }
    }

    public void Update()
    {
        Console.WriteLine("Enter Employee Id : ");
        int empId = Convert.ToInt32(Console.ReadLine());

        Employee prevEmployee = emp.GetEmployee(empId);
        if (prevEmployee == null)
        {
            Console.WriteLine("Employee not found");
            return;
        }

        Console.WriteLine("Enter Employee Name : ");
        string newName = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Enter Employee Salary : ");
        decimal newSalary = Convert.ToDecimal(Console.ReadLine());
        Employee newEmployee = new Employee(empId, newName, newSalary);
        if (emp.UpdateEmployee(newEmployee, empId))
        {
            Console.WriteLine("Updated successfully.");
        }
        else
        {
            Console.WriteLine("Failed to update");
        }
    }

    public void GetAll()
    {
        foreach (Employee employee in emp.Employees)
        {
            Console.WriteLine($"Employee Id : {employee.Id}");
            Console.WriteLine($"Employee Name : {employee.Name}");
            Console.WriteLine($"Employee Salary : {employee.Salary}");
            Console.WriteLine("--------------------------------------");
        }
    }
}
