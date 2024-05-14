using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDemo
{
    internal class Parent : GrandParent
    {
        private string fatherName;
        private string motherName;

        public string FatherName
        {
            get { return fatherName; }
        }
        public string MotherName
        {
            get { return motherName; }
        }

        public Parent(string fatherName, string motherName,string surname): base(surname)
        {
            this.fatherName = fatherName;
            this.motherName = motherName;
        }
    }
}
