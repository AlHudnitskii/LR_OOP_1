namespace OOP_LR1.BankSystem.Core.Models
{
    public class SalaryProject
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string EnterpriseId { get; set; } 
        public string BankId { get; set; } 
        public DateTime StartDate { get; set; } = DateTime.UtcNow; 
        public bool IsActive { get; set; } = true;
    }
}
