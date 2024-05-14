/*
* HelloWorld.cs
* the below code prints the Hello World to output screen.
*/

namespace Day1
{
    internal class HelloWorld
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            AccessSpecifiers ac = new AccessSpecifiers();
            

            AccessSpecifiers2 ac2 = new AccessSpecifiers2();
            
            Console.WriteLine(ac2.isMinor);
            Console.WriteLine(ac2.lName);
            Console.WriteLine(ac2.age);

            Console.ReadLine();
        }
    }
}
