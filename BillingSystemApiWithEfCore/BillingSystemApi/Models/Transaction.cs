﻿namespace BillingSystemApi.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string TransactionFor { get; set; }
        public decimal TransactionsAmount { get; set; }
        public bool IsTransactionSuccessfull { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public int CustomerId { get; set; }
    }   
}