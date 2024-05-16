
namespace GenericListDemo;

public class Utility
{
    public static int ReadInt()

    {
        int userInput = 0;
        bool intParsable = false;

        do
        {
            string stringInput = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(stringInput))
            {
                Console.WriteLine("Error: Input cannot be empty or contain only white spaces.");
                continue;
            }

            intParsable = int.TryParse(stringInput, out userInput);
            if (!intParsable)
            {
                Console.WriteLine("Error: Input should only contain numeric values.");
                continue;
            }

            if (userInput < int.MinValue || userInput > int.MaxValue)
            {
                Console.WriteLine($"Error: Input should be between {int.MinValue} and {int.MaxValue}.");
                intParsable = false;
            }

        } while (!intParsable);

        return userInput;
    }

    public static string ReadString()
    {
        string stringInput = Console.ReadLine() ?? string.Empty;
        while (string.IsNullOrWhiteSpace(stringInput))
        {
            System.Console.WriteLine("Error : Invalid input,Enter valid string");
            stringInput = Console.ReadLine() ?? string.Empty;
        }
        return stringInput;
    }
}

