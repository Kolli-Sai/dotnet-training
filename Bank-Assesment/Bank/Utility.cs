using System;

namespace Bank;

public class Utility
{
    public static decimal ReadDecimalFromConsole(string placeholder)
    {
        decimal decimalInput;
        string stringInput;
        placeholder = placeholder ?? "Enter a decimal value:";

        do
        {
            Console.WriteLine(placeholder);
            stringInput = Console.ReadLine()?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(stringInput))
            {
                Console.WriteLine("Error: Input cannot be empty or contain only whitespaces. Try again!");
                continue;
            }

            if (!decimal.TryParse(stringInput, out decimalInput))
            {
                Console.WriteLine("Error: Input must contain only decimal values. Try again!");
                continue;
            }

            if (decimalInput < decimal.MinValue || decimalInput > decimal.MaxValue)
            {
                Console.WriteLine($"Error: Input must be between {decimal.MinValue} and {decimal.MaxValue}. Try again!");
                continue;
            }


            break;
        } while (true);

        return decimalInput;
    }

    public static int ReadInt32FromConsole(string prompt = "Enter an Integer value:")
    {
        int intInput;
        do
        {
            Console.WriteLine(prompt);
            string stringInput = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(stringInput))
            {
                Console.WriteLine("Error: Input cannot be empty or contain only whitespaces. Try again!");
                continue;
            }

            if (!int.TryParse(stringInput, out intInput))
            {
                Console.WriteLine("Error: Input must contain only integer values. Try again!");
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
                Console.WriteLine("Error : Input shouldn't be null or cannot contain only whitespaces.");
                continue;
            }

            break;
        } while (true);
        return stringInput;
    }
}
