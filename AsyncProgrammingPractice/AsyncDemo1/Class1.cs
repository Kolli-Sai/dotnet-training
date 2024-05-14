using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDemo1
{
    internal class Class1
    {
        public static void SomeMethod()
        {
            Console.WriteLine("Some method started.");
            Thread.Sleep(5000);

            Console.WriteLine("Some method ended.");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main started.");

            SomeMethod();
            Console.WriteLine("Main ended.");
        }
    }
}
