using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
     class AccessSpecifiers2:AccessSpecifiers
    {
       
        static void Main()
        {
            AccessSpecifiers2 accessSpecifiers2 = new AccessSpecifiers2();
            // private variables are not accessible here
            Console.WriteLine(accessSpecifiers2.age);
            Console.WriteLine(accessSpecifiers2.lName);
            Console.WriteLine(accessSpecifiers2.isMajor);
            Console.WriteLine(accessSpecifiers2.isMinor);
            
        }
        
        
    }
}
