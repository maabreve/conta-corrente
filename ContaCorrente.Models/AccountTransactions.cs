using System;
using System.Collections.Generic;

namespace ContaCorrente.Model
{
    public enum TransactionType
    {
        Credit = 1,
        Debit = 2,
        Transfer = 3
    }

    public class AccountTransaction
    {
        public AccountTransaction()
        {
        }

        public int Id { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public TransactionType TransactionType { get; set; }
        public Decimal TransactionValue { get; set; }

        // Account FK
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
