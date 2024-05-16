using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismDemo
{
    internal class Organisation
    {
        public void GiveHike(Employee emp,int salary)
        {
            emp.IncreaseSalary(salary);
            
        }
    }
}
