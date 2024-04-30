namespace Bank;

internal class SavingsAccount : Account
{   
    
    public int transactionsCount { get; set; } = 0;
    public override void Deposit(decimal amount)
    {
        if (transactionsCount >= 5)
        {
            throw new Exception("Max transactions reached");
        }
        if (amount <= 0 )
        {
            throw new Exception("amount shouldn't be less than 0.");
        }
        if(amount > 50000)
        {
            throw new Exception("Max of 50000 are allowed.");
        }
       
            Balance += amount;
        transactionsCount ++;
        
    }

    public override void WithDraw(decimal amount)
    {
        if (transactionsCount >= 5)
        {
            throw new Exception("Max transactions reached");
        }
        if (amount <= 0 )
        {
            throw new Exception("amount shouldn't be less than 0.");

        }
        if (amount > Balance)
        {
            throw new Exception("Insufficient amount.");
        }
        decimal minBalance = Balance - amount;

        if (minBalance < 1000)
        {
            throw new Exception("Minimum Balance of 1000 required in account.");
        }

        if(amount > 50000)
        {
            throw new Exception("Max of 50000 is allowed for transaction");
        }

        Balance -= amount;
        transactionsCount++;
    }
}
