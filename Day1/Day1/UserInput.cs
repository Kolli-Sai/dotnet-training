/*
 * UserInput.cs
 * Add method takes the input from the user and add the two numbers
 * GetSalary method takes the input from the user and processes the data and display the final salary
 * 
 */

namespace Day1
{
    internal class UserInput
    {
        void Add()
        {
            int first, second, result;
            Console.WriteLine("Enter First Number : ");
            first = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Second Number : ");
            second = Convert.ToInt32(Console.ReadLine());
            result = first + second;
            Console.WriteLine($"{first} + {second} = {result}");

        }

        void GetSalary()
        {
            Console.WriteLine("Enter Employee Name: ");
            string empName = Console.ReadLine();
            Console.WriteLine("Enter Employee Age : ");
            int empAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Salary : ");
            int empSalary = Convert.ToInt32(Console.ReadLine());

           

            float salaryPerMonth = empSalary /12;
            Console.WriteLine($"{empName} gets {salaryPerMonth} for month.");

        }
        static void Main()
        {
            Console.WriteLine("UserInputClass");
            UserInput userInput = new UserInput();
            //userInput.Add();
            userInput.GetSalary();
        }
    }
}
