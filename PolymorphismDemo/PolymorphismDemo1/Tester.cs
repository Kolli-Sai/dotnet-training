using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismDemo
{
    internal class Tester : Employee
    {
        public override void IncreaseSalary(int salary)
        {
            Console.WriteLine($"salary Increased {salary} for Tester.");
        }
    }
}
