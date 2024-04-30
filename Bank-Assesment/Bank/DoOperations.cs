﻿namespace Bank;

internal class DoOperations
{

    DummyBank dummyBank = new DummyBank();
    public void DoCreateNewAccount()
    {
        string accountHolderName = Utility.ReadStringFromConsole("Enter Account Holder Name : ");

        Account accountFound = dummyBank.GetAccount(accountHolderName);

        if (accountFound != null)
        {
            Console.WriteLine("Account already there with the userName ");
            return;
        }

        for (int i = 0; i < Enum.GetValues(typeof(AccountType)).Length; i++)
        {
            Console.WriteLine($"{i} for {(AccountType)i}");
        }


        int choosedAccount = Utility.ReadInt32FromConsole("Choose AccountType");



        AccountType accountType = (AccountType)choosedAccount;

        decimal initialBalance = Utility.ReadDecimalFromConsole("Enter Initial Amount : ");

        if (accountType == AccountType.SavingsAccount)
        {
            SavingsAccount sa = new SavingsAccount
            {
                AccountHolderName = accountHolderName,
                Balance = initialBalance,
                BankAccountType = accountType
            };

            dummyBank.CreateNewAccount(sa);

            Console.WriteLine("Account Created successfully");
        }
        else
        {
            FixedDepositAccount fa = new FixedDepositAccount
            {
                AccountHolderName = accountHolderName,
                Balance = initialBalance,
                BankAccountType = accountType
            };
            dummyBank.CreateNewAccount(fa);
            Console.WriteLine("Account Created successfully");

        }


    }

    public void DoWithdraw()
    {
        string accountHolderName = Utility.ReadStringFromConsole("Enter Account Holder Name ");

        Account accountFound = dummyBank.GetAccount(accountHolderName);

        if (accountFound != null)
        {
            try
            {
                int amountToWithdraw = Utility.ReadInt32FromConsole("Enter amount you want to withdraw");
                accountFound.WithDraw(amountToWithdraw);
                Console.WriteLine(accountFound.PrintAccountDetails());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        else
        {
            Console.WriteLine("No Account Found");
            return;
        }
    }

    public void DoDeposit()
    {
        string accountHolderName = Utility.ReadStringFromConsole("Enter Account Holder Name ");

        Account accountFound = dummyBank.GetAccount(accountHolderName);

        if (accountFound != null)
        {
            try
            {
                int amountToDeposit = Utility.ReadInt32FromConsole("Enter amount you want to deposit");
                accountFound.Deposit(amountToDeposit);
                Console.WriteLine(accountFound.PrintAccountDetails());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        else
        {
            Console.WriteLine("No Account Found");
            return;
        }
    }
}
