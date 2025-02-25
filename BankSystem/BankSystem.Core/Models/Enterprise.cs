namespace OOP_LR1.BankSystem.Core.Models
{
    public class Enterprise
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Type { get; set; }
        public string LegalAddress { get; set; } 
        public string TaxNumber { get; set; }
        public string BankId { get; set; } 
        public Bank Bank { get; set; } 
        public List<SalaryProject> SalaryProjects { get; set; } = new List<SalaryProject>();
    }
}
