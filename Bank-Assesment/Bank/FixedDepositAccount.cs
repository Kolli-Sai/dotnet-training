namespace Bank;

internal class FixedDepositAccount : Account
{
    public int withdrawlCount { get; set; } = 0;
    public int depositCount { get; set; } = 0;
    public override void Deposit(decimal amount)
    {
        if (depositCount >= 1)
        {
            throw new Exception("Reached max deposits");
        }

        if (amount <= 0)
        {
            throw new Exception("amount shouldn't be less than 0");
        }

        Balance += amount;
        depositCount++;
    }

    public override void WithDraw(decimal amount)
    {
        if (withdrawlCount>=1)
        {
            throw new Exception("Reached max deposits");
        }

        if (amount <= 0)
        {
            throw new Exception("amount shouldn't be less than 0");
        }

        if (amount > Balance)
        {
            throw new Exception("Insufficient amount");
        }

        Balance -=amount;
        withdrawlCount++;

    }
}
