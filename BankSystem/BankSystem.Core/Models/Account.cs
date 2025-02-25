namespace OOP_LR1.BankSystem.Core.Models
{
    public class Account
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string AccountNumber { get; set; }
        public bool IsBlocked { get; set; } = false;

        public decimal Balance { get; set; }
        public string OwnerId { get; set; } 
        public User Owner { get; set; } 
        public string BankId { get; set; }  
        public Bank Bank { get; set; } 
    }
}
