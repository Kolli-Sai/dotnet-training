using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class DepositTransaction
    {

        // fields
        private Account _account;
        private decimal _amount;
        private bool _executed = false;
        private bool _success = false;
        private bool _reversed = false;



        // properties
        public Account Account
        {
            get
            {
                return _account;
            }
            set
            {
                _account = value;
            }
        }
        public decimal Amount
        {
            get
            {
                return this._amount;
            }
            set
            {
                this._amount = value;
            }
        }

        public bool Executed { get { return _executed; } }
        public bool Success { get { return _success; } }
        public bool Reversed { get { return _reversed; } }

        public DepositTransaction(Account account, decimal amount)
        {
            this.Account = account;
            this.Amount = amount;
        }

        public void Execute()
        {
            if (this.Executed)
            {
                throw new Exception("cannot execute this transaction as it has already executed.");
            }

            if (this.Account.Deposit(Amount))
            {


                this._success = true;
            }
            this._executed = true;


        }

        public void Rollback()
        {
            if (!this._executed)
            {

                throw new Exception("Transaction has not executed yet!");
            }

            else if (this._reversed)
            {
                throw new Exception("Transaction has been reversed.");
            }
            else
            {

                //this.Account.Deposit(this.Amount);

                this._reversed = true;
            }

        }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            if (Success)
            {

                sb.AppendFormat("Transaction details for {0} Account Number{1}", this.Account.AccountNumber, Environment.NewLine);
                sb.AppendFormat("Deposited  amount : {0}{1}", this.Amount, Environment.NewLine);

                decimal finalBalance = this.Account.Balance;
                sb.AppendFormat("Final Balance : {0}{1}", finalBalance, Environment.NewLine);

                sb.AppendFormat("Executed : {0}{1}", this.Executed, Environment.NewLine);
                sb.AppendFormat("Success : {0}{1}", this.Success, Environment.NewLine);
                sb.AppendFormat("Reversed : {0}{1}", this.Reversed, Environment.NewLine);
            }
            else
            {
                sb.AppendFormat("Transaction Failed..");
            }


            return sb.ToString();
        }


    }
}
