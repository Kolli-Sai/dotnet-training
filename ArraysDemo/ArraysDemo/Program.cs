using System.Linq;
/*
 * practice on Arrays
 * 
 */
namespace ArraysDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // array declaration
            int[] arrayDeclaration;

            // size allocation

            int[] sizeAllocation = new int[5];

            // size allocation while declaring

            int[] allocationWhileDeclaring = new int[5];

            // initializing values

            int[] initialisingwhileDeclaration = new int[5] {1,2,3,4,5};
            // it will allocate the memory automatically even if we dont mention the size if we initialize the values
            int[] automaticMemoryAllocation = new int[] {1,2,3,4,5};

            //shorter syntax

            int[] shortSyntax = {1,2,3,4,5};

            // this will only work if we are initializing when declaring
            // we have to use new keyword if we are initializing after declaration

            int[] a;
            a= new int[] {1,2,3,4,6};

            int[] numbers = {1,2,3,4,5};
            

            // accessing array elements
            Console.WriteLine($"3rd element {numbers[2]}");

            // change array elements
            numbers[2] = 10;
            Console.WriteLine($"3rd element {numbers[2]}");

            // iterating the array using for loop

            for(int i=0;i<numbers.Length;i++)
            {
                Console.WriteLine(numbers[i]);
            }

            // iterating the array using forEach loop


            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }

            // we can use different predefined methods on arrays by using System.Linq namespace

            Console.WriteLine($"Min of numbers {numbers.Min()}");
            Console.WriteLine($"Max of numbers {numbers.Max()}");

            // like that we have so many methods availble in System.Linq namespace
            // multi dimensional arrays

            int[,] twoDimensionalArrays = { { 1, 2, 3 },{ 4, 5,6 } };
            // accessing 2-d array elements

            Console.WriteLine("2-d array " + twoDimensionalArrays[0,1]);
            // changing 2-d array elements

            twoDimensionalArrays[0, 1] = 10;
            Console.WriteLine("2-d array " + twoDimensionalArrays[0,1]);

        }
    }
}
