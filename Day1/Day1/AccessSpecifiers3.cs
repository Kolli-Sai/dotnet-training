using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class AccessSpecifiers3
    {
        static void Main()
        {
            // private are not accessible 
            // protected are not accessible

            AccessSpecifiers accessSpecifiers = new AccessSpecifiers();
            Console.WriteLine(accessSpecifiers.age);
            Console.WriteLine(accessSpecifiers.lName);
            Console.WriteLine(accessSpecifiers.isMinor);
            
        }
    }
}
