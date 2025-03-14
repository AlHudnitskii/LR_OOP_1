﻿namespace OOP_LR1.BankSystem.Core.Models
{
    public class Transaction
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FromAccountId { get; set; } 
        public string ToAccountId { get; set; }
        public decimal Amount { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
