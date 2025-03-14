namespace OOP_LR1.BankSystem.Core.Models
{
    public class Account
    {
        public string Id { get; set; }
        public string AccountNumber { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsFrozen { get; set; }

        public decimal Balance { get; set; }
        public string OwnerId { get; set; } 
        public User Owner { get; set; } 
        public string BankId { get; set; }  
        public Bank Bank { get; set; } 
    }
}
