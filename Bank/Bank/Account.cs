using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class Account

    {
        
        // properties
        public string AccountNumber { get; }
        public decimal Balance { get; set; }

        // constructor
        public Account(string accountNumber,decimal balance) { 
            this.AccountNumber = accountNumber;
            this.Balance = balance;
        }

        public bool Withdraw(decimal amount)
        {
            if(amount < 0)
            {
                return false;
            }
            if(amount <= Balance)
            {

            Balance -= amount;

                return true;
            }
           else {
                return false;
            }
        }

        public bool Deposit(decimal amount)
        {
            if(amount >0)
            {

            Balance += amount;
            return true;
            }
            else
            {
                return false;
            }
        }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("AccountNumber : {0}{1}",this.AccountNumber,Environment.NewLine);
            sb.AppendFormat("Balance : {0}{1}",this.Balance,Environment.NewLine);
            return sb.ToString();
        }
    }
}
