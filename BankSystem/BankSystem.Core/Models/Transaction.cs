namespace OOP_LR1.BankSystem.Core.Models
{
    public class Transaction
    {
        public string Id { get; set; } = Guid.NewGuid().ToString(); 
        public string SenderAccountNumber { get; set; } 
        public string ReceiverAccountNumber { get; set; } 
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
