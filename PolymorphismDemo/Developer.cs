using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismDemo
{
    internal class Developer : Employee
    {
        public string role = "Developer";
        public override void IncreaseSalary(int salary)
        {
            
            Console.WriteLine($"Salary increased {salary} for Developer.");
        }
    }
}
