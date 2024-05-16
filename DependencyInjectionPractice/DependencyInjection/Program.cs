namespace DependencyInjectionPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ConstructorEmployeeBL employee = new ConstructorEmployeeBL(new ConstructorEmployeeDAL());
            employee.GetAllEmployees().ForEach(x => Console.WriteLine(x.Name));
        }
    }
}
