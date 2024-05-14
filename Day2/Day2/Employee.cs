using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Employee.cs
 * Employee class represents fields, properties and methods 
 * 
 */

namespace Day2
{
    internal class Employee
    {
        // fields
        private string name;
        private int age;
        private int salaryPerAnnum;

        // properties

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }

        }

        public int SalaryPerAnnum 
        { 
            get { return salaryPerAnnum; } 
            set { salaryPerAnnum = value; } 
        }


        // methods

        public void AssignValues(string name,int age,int salaryPerAnnum) {
            
            this.name = name;
            this.age = age;
            this.SalaryPerAnnum= salaryPerAnnum;
        }


        public string GetMonthlySalary()
        {
            float Hra = 10/100f;
            float Pf = 5/100f;
            float hraAmount = salaryPerAnnum * Hra;
            float pfAmount = salaryPerAnnum * Pf;
            float final = salaryPerAnnum - (hraAmount + pfAmount)/12;

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} gets {1} per month.",name,final);
            return sb.ToString();
        }
        
    }
}
