namespace Bank
{
    public enum MenuOption
    {
        Withdraw,
        Deposit,
        Transfer,
        Print,
        Quit
    }

    delegate bool DelegatePointer(decimal amount);

    internal class Program
    {
        static MenuOption ReadUserOption()
        {
            int userOption;
            do
            {
                Console.WriteLine("Enter one number based on your requirement ");
                Console.WriteLine($"0 for {MenuOption.Withdraw}");
                Console.WriteLine($"1 for {MenuOption.Deposit}");
                Console.WriteLine($"2 for {MenuOption.Transfer}");
                Console.WriteLine($"3 for {MenuOption.Print}");
                Console.WriteLine($"4 for {MenuOption.Quit}");

                userOption = Convert.ToInt32(Console.ReadLine());
            } while (userOption < 0 || userOption > 3);
            return (MenuOption)userOption;
        }

        static void DoDeposit(Account account, decimal amount)
        {
            DepositTransaction dt = new DepositTransaction(account, amount);
            dt.Execute();
            if (dt.Success)
            {

                Console.WriteLine(dt.Print());
            }
            else
            {
                dt.Rollback();
                Console.WriteLine(dt.Print());

            }

        }

        static void DoWithdraw(Account account, decimal amount)
        {
            // account.Withdraw(amount);
            WithdrawTransaction wt = new WithdrawTransaction(account, amount);

            wt.Execute();
            if (wt.Success)
            {

                Console.WriteLine(wt.Print());
            }
            else
            {
                wt.Rollback();
                Console.WriteLine(wt.Print());

            }

        }





        static string DoPrint(Account account)
        {
            return account.Print();
        }

        static void DoOperation(Account account, MenuOption option)
        {
            switch (option)
            {
                case MenuOption.Withdraw:
                    Console.WriteLine("How much money you would like to withdraw?");
                    decimal amount = Convert.ToDecimal(Console.ReadLine());
                    DoWithdraw(account, amount);
                    break;
                case MenuOption.Deposit:
                    Console.WriteLine("How much money you would like to Deposit?");
                    decimal amount2 = Convert.ToDecimal(Console.ReadLine());
                    DoDeposit(account, amount2);
                    break;
                case MenuOption.Transfer:
                    Console.WriteLine("Enter the reciever account name : ");
                    string reciever = Console.ReadLine();
                    Account ac2 = new Account(reciever, 1000.00m);
                    Console.WriteLine("How much money you would like to transfer!");
                    decimal amount3 = Convert.ToDecimal(Console.ReadLine());

                    break;
                case MenuOption.Print:
                    DoPrint(account);
                    break;
                default:
                    Console.WriteLine("nothing");
                    break;
            }
        }
        static void Main(string[] args)
        {
            // Console.WriteLine("Welcome to the Bank...");
            // Console.WriteLine("Enter your Account Number : ");
            // string accNumber = Console.ReadLine();
            // Account ac1 = new Account(accNumber, 1000.00m);

            // while (true)
            // {
            //     MenuOption option = ReadUserOption();

            //     if(option == MenuOption.Print)
            //         Console.WriteLine(ac1.Print());

            //     if (option == MenuOption.Quit)
            //         break; 

            //     DoOperation(ac1, option);

            // }

            Account account1 = new Account("sai", 1200.00m);
            DelegatePointer dWithdraw;
            DelegatePointer dDeposit;
            DelegatePointer combined;
            dWithdraw = new DelegatePointer(account1.Withdraw);
            dDeposit = new DelegatePointer(account1.Deposit);
            combined = dWithdraw;
            combined += dDeposit;
            dWithdraw(300);
            System.Console.WriteLine("after withdrw");
            System.Console.WriteLine($"Current Balance : {account1.Balance}");
            System.Console.WriteLine("after deposit");
            dDeposit(200);
            System.Console.WriteLine("after both");
            System.Console.WriteLine($"Current Balance : {account1.Balance}");
            combined(500);
            System.Console.WriteLine($"Current Balance : {account1.Balance}");

        }

    }
}
