using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDemo1
{
    internal class Class2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Method Started......");
            SomeMethod();
            Console.WriteLine("Main Method End");
            Console.ReadKey();
        }
        public async static void SomeMethod()
        {
            Console.WriteLine("Some Method Started......");
            //Thread.Sleep(TimeSpan.FromSeconds(10));
            //await Task.Delay(TimeSpan.FromSeconds(10));
            await Wait();
            Console.WriteLine("\n");
            Console.WriteLine("Some Method End");
        }

        private static async Task Wait()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine("\n5 Seconds wait Completed\n");
        }
    }
}
