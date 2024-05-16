﻿using BillingSystem.Enums;

namespace BillingSystem.Models
{
    public class CreateTransactionRequest
    {
        public decimal TransactionAmount { get; set; }
        public ETransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsTransactionSuccessfull { get; set; }
    }
}