using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDemo
{
    internal class Child : Parent
    {
        private string childName;

        public string ChildName
        {
            get { return childName; }
        }
        public Child(string childName, string fatherName, string motherName, string surName) : base(fatherName, motherName,surName)
        {
            this.childName = childName; 
        }
    }
}
