namespace BillingSystem;

public enum MenuOptions
{
    InvoiceGeneration,
    InvoiceHistory,
    TransactionHistory,
    TotalRevenue,

    Exit
}
public interface IMenu
{
    void ShowMenu();
}
internal class Menu: IMenu
{
    

    public void ShowMenu()
    {

        DoOperations doOperations = new DoOperations();
        while (true)
        {
            for (int i = 0; i < Enum.GetValues(typeof(MenuOptions)).Length; i++)
            {
                MenuOptions option = (MenuOptions)i;
                Console.WriteLine($"{i} for {option}");
            }

            int choosedNumber = Utility.ReadInt32FromConsole("Choose one method:");
            MenuOptions choosedOption = (MenuOptions)choosedNumber;

            if (choosedOption == MenuOptions.Exit)
            {
                break;
            }

            switch (choosedOption)
            {
                case MenuOptions.InvoiceGeneration:
                    doOperations.DoInvoiceGeneration();
                    break;
                case MenuOptions.InvoiceHistory:
                    doOperations.DoInvoiceHistory();
                    break;
                case MenuOptions.TransactionHistory:
                    doOperations.DoTransactionHistory();
                    break;
                case MenuOptions.TotalRevenue:
                    doOperations.DoTotalRevenue();
                    break;
                case MenuOptions.Exit:
                    break;
                default:
                    break;
            }
        }
    }
}

public class ShowMenu
{
    private readonly IMenu _menu;

    public ShowMenu(IMenu menu)
    {
        _menu = menu;
    }

    public void show()
    {
        _menu.ShowMenu();
    }
    
}

public class ShowMenuBuilder
{
    private IMenu _menu;

    public ShowMenuBuilder WithMenu(IMenu menu)
    {
        _menu = menu;
        return this;
    }

    public ShowMenu Build()
    {
        return new ShowMenu(_menu);
    }
}
