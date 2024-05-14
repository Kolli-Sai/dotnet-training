/*
 * DataTypes.cs
 * Below Program Prints the all the dataTypes availble in c# to Console.
 */
namespace Day1
{
    class DataTypes
    {
        // variables

        // Declaring variables : <dataType> variableName;
        int age;

        // assigning values to variables
        //age = 20 

        // declaring with initialisation
        string name = "sai";



        // DATA TYPES

        // =================================================================

        // SIGNED INTEGER TYPES :  These data types hold integer values (both positive and negative). Out of the total available bits

        // 1, sbyte (-128,127)
        sbyte sbyteExample = -23; // DefaultValue = 0

        // 2, short ( -32,768 to 32,767)
        short shortExample = 1000; // DefaultValue = 0

        // 3, int
        int intExample = 1000; // DefaultValue = 0

        // 4, long : suffix with "L" otherwise it will treat it as Int32(int)
        long longExample = 234566L;  // DefaultValue = 0L

        // =================================================================


        // UNSIGNED INTEGER DATA TYPES : these data types hold values that are >=0 and the range of the type.

        // byte (0,255)
        byte byteExample = 255;  // DefaultValue = 0

        // ushort
        ushort ushortExample = 1000;  // DefaultValue = 0

        // uint 
        uint uintExample = 234556;  // DefaultValue = 0

        // ulong : suffix with L
        //ulong ulongExample = -28899L; if we use negative values it throws errors
        ulong ulongExample = 234455L;  // DefaultValue = 0L

        // =================================================================

        // FLOAT DATA TYPES 

        // float : suffix with F by default it have double
        float floatExample = 1.23F;  // DefaultValue = 0.0F

        // double (Default) : suffix with D(no Need)
        double doubleExample = 1.2000D;  // DefaultValue = 0.0D

        // decimal : suffix with M , by  default it have double
        decimal decimalExample = 100.234M;  // DefaultValue = 0.0M

        // =================================================================

        // char : it can hold a single character values in single quotes
        char charExample = 'A';  // DefaultValue = '\0'

        // bool : it can store either true or false;
        bool boolExample = false;  // DefaultValue = false


        static void Main()
        {
            DataTypes dataTypes = new DataTypes();
            // displaying output using string concatenation
            Console.WriteLine("sbyte " + dataTypes.sbyteExample);
            Console.WriteLine("short " + dataTypes.shortExample);
            Console.WriteLine("int " + dataTypes.intExample);
            Console.WriteLine("long " + dataTypes.longExample);

            // displaying output using Composite format string
            Console.WriteLine("byte {0}", dataTypes.byteExample);
            Console.WriteLine("ushort {0}", dataTypes.ushortExample);
            Console.WriteLine("uint {0}", dataTypes.uintExample);
            Console.WriteLine("ulong {0}", dataTypes.ulongExample);

            // displaying output using string interpolation
            Console.WriteLine($"float {dataTypes.floatExample}");
            Console.WriteLine($"double {dataTypes.doubleExample}");
            Console.WriteLine($"decimal {dataTypes.decimalExample}");
            Console.WriteLine($"char {dataTypes.charExample}");
            Console.WriteLine($"bool {dataTypes.boolExample}");

        }
    }
}
