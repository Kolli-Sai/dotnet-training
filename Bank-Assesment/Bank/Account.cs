using System.Text;

namespace Bank;

public abstract class Account
{
    public string AccountNumber { get; set; }
    public AccountType BankAccountType { get; set; }
    public string  AccountHolderName { get; set; }
    public decimal Balance { get; set; }

    public abstract void WithDraw(decimal amount);
    public abstract void Deposit(decimal amount);

  

    public string PrintAccountDetails()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendFormat("AccountNumber  : {0}{1}",AccountNumber,Environment.NewLine);
        
        sb.AppendFormat("AccountType : {0}{1}",BankAccountType,Environment.NewLine);
        sb.AppendFormat("AccountHolderName : {0}{1}",AccountHolderName,Environment.NewLine);
        sb.AppendFormat("CurrentBalance : {0}{1}",Balance,Environment.NewLine);
        return sb.ToString();
    }
}
