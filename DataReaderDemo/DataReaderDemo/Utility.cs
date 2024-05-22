namespace DataReaderDemo;

internal class Utility
{
    public static int ReadInt32FromConsole(string placeholder)
    {
        string stringInput;
        int intInput;
        do
        {
            Console.WriteLine(placeholder);
            stringInput = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(stringInput))
            {
                Console.WriteLine("Error : Invalid Input,must enter a value and cannot contain only whitespaces.");
                continue;
            }

            if (!int.TryParse(stringInput, out intInput))
            {
                Console.WriteLine("Error : Invalid Input,Input should contain only Integer values.");
                continue;
            }

            if (intInput < int.MinValue || intInput > int.MaxValue)
            {
                Console.WriteLine($"Error : Invalid Input,Input must be between {int.MinValue} and {int.MaxValue}.");
                continue;
            }
            break;


        } while (true);
        return intInput;
    }

    public static string ReadStringFromConsole(string placeholder)
    {
        string stringInput;
        do
        {
            Console.WriteLine(placeholder);
            stringInput = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(stringInput))
            {
                Console.WriteLine("Error :Invalid Input,input cannot be empty or cannot contain only white spaces.");
                continue;
            }
            break;
        } while (true);
        return stringInput;
    }

}
