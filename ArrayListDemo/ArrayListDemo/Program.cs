
namespace ArrayListDemo;

public enum MenuOptions
{
    AddEmployee,
    RemoveEmployee,
    UpdateEmployee,
    GetEmployees,
    Quit
}

internal class Program
{
    static DoOperations doOperations = new DoOperations();
    static void ChooseOperation(int userOption)
    {
        MenuOptions menuOption = (MenuOptions)userOption;
        switch (menuOption)
        {
            case MenuOptions.AddEmployee:
                doOperations.Add();
                break;
            case MenuOptions.RemoveEmployee:
                doOperations.Remove();
                break;
            case MenuOptions.UpdateEmployee:
                doOperations.Update();
                break;
            case MenuOptions.GetEmployees:
                doOperations.GetAll();
                break;
            default:
                Console.WriteLine("Invalid Input!!");
                break;
        }
    }

    public static void TakeUserInput()
    {


        while (true)
        {
            Console.WriteLine($"Choose any method ");
            Console.WriteLine($"0 for {MenuOptions.AddEmployee}");
            Console.WriteLine($"1 for {MenuOptions.RemoveEmployee}");
            Console.WriteLine($"2 for {MenuOptions.UpdateEmployee}");
            Console.WriteLine($"3 for {MenuOptions.GetEmployees}");
            Console.WriteLine($"4 for {MenuOptions.Quit}");
            Console.WriteLine("Enter one number : ");
            int userOption = Convert.ToInt32(Console.ReadLine());
            if (userOption == 4)
            {
                break;
            }

            ChooseOperation(userOption);
        }
    }

    public static void Main(string[] args)
    {
        TakeUserInput();
    }
}
