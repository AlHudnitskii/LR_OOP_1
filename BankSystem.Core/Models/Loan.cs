namespace OOP_LR1.BankSystem.Core.Models
{
    public class Loan
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; } 
        public decimal Amount { get; set; } 
        public decimal InterestRate { get; set; } 
        public int TermInMonths { get; set; } 
        public DateTime StartDate { get; set; } = DateTime.UtcNow; 
        public bool IsPaid { get; set; } = false;
    }
}
