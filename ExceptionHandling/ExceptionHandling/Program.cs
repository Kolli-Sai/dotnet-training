namespace ExceptionHandling;

class NullInputException : Exception
{
    public NullInputException() : base("Input Cannot be Null")
    {

    }
}

class EmptyInputException : Exception
{
    public EmptyInputException() : base("Input Cannot be Empty and cannot contain only white spaces!") { }
}

class InvalidIntInputException : Exception
{
    public InvalidIntInputException() : base("Input should contain only numbers") { }
}
class Program
{
    public void NestedHandling()
    {

        try
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();


            try
            {
                int number = int.Parse(input);
                Console.WriteLine("Entered number: " + number);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number format!");
            }
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Input cannot be null!");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
    static void Main(string[] args)
    {
        try
        {
            System.Console.WriteLine("Enter your age : ");
            string readInput = Console.ReadLine();
            if (string.IsNullOrEmpty(readInput))
            {
                throw new NullInputException();
            }

            if (string.IsNullOrWhiteSpace(readInput))
            {
                throw new EmptyInputException();
            }


            bool result = int.TryParse(readInput, out int value);
            if (!result)
            {
                throw new InvalidIntInputException();
            }
            else
            {

                int age = value;
            }

            System.Console.WriteLine("After throwing");

        }
        catch (NullInputException ex)
        {

            System.Console.WriteLine(ex.Message);
        }

        catch (EmptyInputException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        catch (InvalidIntInputException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }

        System.Console.WriteLine("after try");
    }
}