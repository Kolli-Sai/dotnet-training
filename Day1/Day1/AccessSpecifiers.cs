using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class AccessSpecifiers
    {
        public int age = 20;
        private string fName = "sai";
        protected bool isMajor = true;
        internal bool isMinor = false;
        protected internal string lName = "kolli";
        string fullName = "sai kolli"; // default private all members

        static void Main()
        {
            // private is accessible only within class
            AccessSpecifiers accessSpecifiers = new AccessSpecifiers();
            Console.WriteLine(accessSpecifiers.age);
            Console.WriteLine(accessSpecifiers.fName);
            Console.WriteLine(accessSpecifiers.lName);
            Console.WriteLine(accessSpecifiers.fullName);
            Console.WriteLine(accessSpecifiers.isMinor);
            Console.WriteLine(accessSpecifiers.isMajor);

        }
    }



}
