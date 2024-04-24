

using GSTCalculationProgram;
using GSTCaluclationProgram;

class Program
{
    static Gst gst = new Gst();
    static void ChooseOperation(ChooseState statePreference, decimal productPrice)
    {
        switch (statePreference)
        {
            case ChooseState.IntraState:
                gst.CaluclateIntraStateTransactions(productPrice);
                System.Console.WriteLine(gst.GetIntraStateTransactions());
                break;
            case ChooseState.InterState:
                gst.CaluclateInterStateTransaction(productPrice);
                System.Console.WriteLine(gst.GetInterStateTransactions());
                break;
            default:
                System.Console.WriteLine("Invalid input");
                break;
        }
    }

    static decimal ReadProductPriceFromConsole()
    {
        decimal productPrice = Utility.ReadDecimalFromConsole("Enter Product price:");
        return productPrice;

    }
    static ChooseState ReadStateFromConsole()
    {
        System.Console.WriteLine("Choose where the transaction occurs!");

        System.Console.WriteLine($"{(int)ChooseState.IntraState} for {ChooseState.IntraState}(within the state)");
        System.Console.WriteLine($"{(int)ChooseState.InterState} for {ChooseState.InterState}(Outside the state)");

        int userChoice = Utility.ReadInt32FromConsole("Enter where the transaction occurs : ");
        if (userChoice < 1 || userChoice > 2)
        {
            userChoice = Utility.ReadInt32FromConsole("Enter where the transaction occurs : ");
        }
        return (ChooseState)userChoice;
    }

    public static void Main(string[] args)
    {
        decimal productPrice = ReadProductPriceFromConsole();
        ChooseState statePreference = ReadStateFromConsole();
        ChooseOperation(statePreference, productPrice);
    }
}