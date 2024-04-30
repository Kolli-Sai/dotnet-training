namespace Bank;

internal class DummyBank
{
    List<Account> accounts = new List<Account>();

    public void CreateNewAccount(Account newAccount)
    {
        accounts.Add(newAccount);
    }

    public Account GetAccount(string accountName)
    {
        foreach (var account in accounts)
        {
            if(account.AccountHolderName == accountName)
            {
                return account;
            }
        }
        return null;
    }
}
