namespace Day2
{
    internal class Program


    {

     
        static void Main(string[] args)
        {
            try
            {

            
            Console.WriteLine("Enter Employee Name : \n");
            string name = Console.ReadLine() ?? string.Empty;

            if(string.IsNullOrWhiteSpace(name))
            {
                var message = "Invalid input, Null or Empty values are not allowed.";
                Console.WriteLine($"{message} \nEnter Employee Name : ");


                var nameValue = Console.ReadLine();

                name =   string.IsNullOrWhiteSpace(nameValue) ?  throw new ArgumentNullException(message):nameValue;

            }
           

            Console.WriteLine("Enter Employee Age : ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee SalaryPerAnnum : ");
            int salary = Convert.ToInt32(Console.ReadLine());

            Employee employee = new();
            employee.AssignValues(name,age,salary);
            employee.GetMonthlySalary();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
