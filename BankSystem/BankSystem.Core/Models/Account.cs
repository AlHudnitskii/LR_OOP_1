namespace OOP_LR1.BankSystem.Core.Models
{
    public class Account
    {
        public string AccountNumber { get; set; } = Guid.NewGuid().ToString();
        public decimal Balance { get; set; }
        public bool IsBlocked { get; set; } = false;
        public bool IsFrozen { get; set; } = false;
        public string UserId { get; set; }
    }
}
