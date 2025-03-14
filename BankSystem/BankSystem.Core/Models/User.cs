using System.ComponentModel.DataAnnotations;
using System.Data;

namespace OOP_LR1.BankSystem.Core.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentType { get; set; }
        public string Citizenship { get; set; }
        public string CountryOfResidence { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsApproved { get; set; }
        public Role Role { get; set; }
        public string BankId { get; set; } 
        public Bank Bank { get; set; } 
        public ICollection<Account> Accounts { get; set; } = new List<Account>();

    }
}
