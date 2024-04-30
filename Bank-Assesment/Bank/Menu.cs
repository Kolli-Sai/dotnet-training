namespace Bank;

public enum MenuOptions
{
    NewAccount,
    Wthdraw,
    Deposit,
    Exit
}
internal class Menu
{
    public static void ShowMenu()
    {
        DoOperations doOperations = new DoOperations();
        while (true)
        {

            for (int i = 0; i < Enum.GetValues(typeof(MenuOptions)).Length; i++)
            {
                Console.WriteLine($"{i} for {(MenuOptions)i}");
            }

            int userChoice = Utility.ReadInt32FromConsole("Choose one method");

            if(userChoice <0|| userChoice>Enum.GetValues(typeof (MenuOptions)).Length ) 
            {
                Console.WriteLine("Enter Valid value");
                continue;
            }

            MenuOptions choosedOption = (MenuOptions)userChoice;

            if (choosedOption == MenuOptions.Exit)
            {
                break;
            }
            switch (choosedOption)
            {
                case MenuOptions.NewAccount:
                    doOperations.DoCreateNewAccount();
                    break;
                case MenuOptions.Wthdraw:
                    doOperations.DoWithdraw();
                    break;
                case MenuOptions.Deposit:
                    doOperations.DoDeposit();
                    break;
                case MenuOptions.Exit:
                    break;
                default:
                    break;
            }
        }
    }
}
