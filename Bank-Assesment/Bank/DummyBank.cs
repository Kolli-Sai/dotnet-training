namespace Bank;

internal class DummyBank
{
    List<Account> accounts = new List<Account>();

    public void CreateNewAccount(Account newAccount)
    {
        accounts.Add(newAccount);
    }

    public Account GetAccount(string accountNumber)
    {
        foreach (var account in accounts)
        {
            if(account.AccountNumber == accountNumber)
            {
                return account;
            }
        }
        return null;
    }

    public List<Account> GetAccounts(){
        return accounts;
    }
}
