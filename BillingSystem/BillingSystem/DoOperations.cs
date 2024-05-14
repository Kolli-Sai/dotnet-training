namespace BillingSystem;

public enum TypeOfCustomer
{
    NewCustomer,
    ExistingCustomer,
}

internal class DoOperations
{
    //private readonly BillingSystemDbContext _billingSystemDbContext;

    //public DoOperations(BillingSystemDbContext billingSystemDbContext)
    //{
    //    _billingSystemDbContext = billingSystemDbContext;
    //}
    TransactionOperations transactionOperations = new TransactionOperations();
    public void DoInvoiceGeneration()
    {
        for (int i = 0; i < Enum.GetValues(typeof(TypeOfCustomer)).Length; i++)
        {
            Console.WriteLine($"{i} for {(TypeOfCustomer)i}");

        }

        int choosedNumber = Utility.ReadInt32FromConsole("Choose one :");
        if (choosedNumber < 0 || choosedNumber > Enum.GetValues(typeof(TypeOfCustomer)).Length - 1)
        {
            Console.WriteLine("Choose within the range.");
            return;
        }
        TypeOfCustomer choosedOption = (TypeOfCustomer)choosedNumber;


        for (int i = 0; i < Enum.GetValues(typeof(TransactionTypes)).Length; i++)
        {
            Console.WriteLine($"{i} for {(TransactionTypes)i}");

        }

        int choosedTransactionNumber = Utility.ReadInt32FromConsole("which type of transaction it is?");

        TransactionTypes transactionTypes = (TransactionTypes)choosedTransactionNumber;
        DateOnly transactionDate = DateOnly.FromDateTime(DateTime.Now);
        decimal transactionAmount = Utility.ReadDecimalFromConsole("Enter Transaction Amount : ");
        bool isTransactionSuccessfull = Utility.ReadBoolFromConsole("Is Transaction Successfull ");


        Transaction resultTransaction;
        if (choosedOption == TypeOfCustomer.NewCustomer)
        {
            string customerName = Utility.ReadStringFromConsole("Enter customer Name : ");

            Transaction newTransaction = new Transaction
            {
                TransactionId = Guid.NewGuid().ToString(),
                TransactionTypes = transactionTypes,
                TransactionAmount = transactionAmount,
                TransactionDate = transactionDate,
                IsTransactionSuccessfull = isTransactionSuccessfull,
                CustomerId = Guid.NewGuid().ToString(),
                CustomerName = customerName


            };

            try
            {

                resultTransaction = transactionOperations.CreateCustomer(newTransaction);
                Console.WriteLine(transactionOperations.GenerateInvoice(resultTransaction));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }

        if (choosedOption == TypeOfCustomer.ExistingCustomer)
        {
            string customerId = Utility.ReadStringFromConsole("Enter CustomerId : ");

        Transaction customerFound = transactionOperations.GetCustomer(customerId);
            if(customerFound != null)
            {
                Transaction newTransaction = new Transaction
                {
                    TransactionId = Guid.NewGuid().ToString(),
                    TransactionTypes = transactionTypes,
                    TransactionAmount = transactionAmount,
                    TransactionDate = transactionDate,
                    IsTransactionSuccessfull = isTransactionSuccessfull,
                    CustomerId = customerFound.CustomerId,
                    CustomerName = customerFound.CustomerName


                };

                try
                {

                    resultTransaction = transactionOperations.CreateCustomer(newTransaction);
                    Console.WriteLine(transactionOperations.GenerateInvoice(resultTransaction));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            else
            {
                Console.WriteLine("Customer not Found!");
            }
        }


    }

    public void DoInvoiceHistory()
    {
        string customerId = Utility.ReadStringFromConsole("Enter CustomerId:");
        try
        {

        List<Transaction> transactions = transactionOperations.InvoiceHistory(customerId);
        foreach (Transaction transaction in transactions)
        {
            Console.WriteLine(transactionOperations.GenerateInvoice(transaction));
        }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }

    }

    public void DoTransactionHistory()
    {
        string customerId = Utility.ReadStringFromConsole("Enter CustomerId:");
        try
        {

            List<Transaction> transactions = transactionOperations.InvoiceHistory(customerId);
            foreach (Transaction transaction in transactions)
            {
                Console.WriteLine(transactionOperations.GeneratePaymentHistory(transaction));
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
    }

    public void DoTotalRevenue()
    {
        string customerId = Utility.ReadStringFromConsole("Enter CustomerId: ");

        try
        {
            Transaction customerFound = transactionOperations.GetCustomer(customerId);

            if (customerFound != null)
            {
                decimal revenue = transactionOperations.ReportTotalRevenue(customerId);

                Console.WriteLine("\n-----------------------------------------");
                Console.WriteLine($"Total Revenue for Customer ID: {customerId}");
                Console.WriteLine($"Revenue Amount: {revenue:C}");
                Console.WriteLine("-----------------------------------------\n");
            }
            else
            {
                Console.WriteLine($"Customer with ID '{customerId}' not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
