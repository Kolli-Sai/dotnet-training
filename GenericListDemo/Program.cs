
namespace GenericListDemo;
public enum Menu
{
    AddProduct,
    GetProducts,
    UpdateProduct,
    DeleteProduct,
    Quit
}

class Program
{
    static ProductOperations productOperations = new ProductOperations();
    static DoOperations doOperations = new DoOperations();
    public static void ChooseOperation(int userInput)
    {
        Menu menu = (Menu)userInput;

        switch (menu)
        {
            case Menu.AddProduct:
                doOperations.Add();
                break;
            case Menu.GetProducts:
                doOperations.Get();
                break;
            case Menu.UpdateProduct:
                doOperations.Update();
                break;
            case Menu.DeleteProduct:
                doOperations.Remove();
                break;
            case Menu.Quit:
                break;
            default:
                System.Console.WriteLine("No method to execute");
                break;
        }
    }
    public static void TakeUserInput()
    {
        int userOption;
        while (true)
        {


            System.Console.WriteLine("Choose any of the Method.");
            System.Console.WriteLine($"{(int)Menu.AddProduct} for {Menu.AddProduct}");
            System.Console.WriteLine($"{(int)Menu.GetProducts} for {Menu.GetProducts}");
            System.Console.WriteLine($"{(int)Menu.UpdateProduct} for {Menu.UpdateProduct}");
            System.Console.WriteLine($"{(int)Menu.DeleteProduct} for {Menu.DeleteProduct}");
            System.Console.WriteLine($"{(int)Menu.Quit} for {Menu.Quit}");
            userOption = Utility.ReadInt();
            while (userOption < 0 || userOption > 4)
            {
                System.Console.WriteLine("Please choose with in the Range!");
                userOption = Utility.ReadInt();
            }
            if (userOption == 4)
            {
                break;
            }
            ChooseOperation(userOption);
        }
    }
    static void Main(string[] args)
    {

        TakeUserInput();
    }
}

