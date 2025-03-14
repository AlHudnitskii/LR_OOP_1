﻿namespace OOP_LR1.BankSystem.Core.Models
{
    public class Bank
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public List<Account> Accounts { get; set; } = new List<Account>();
        public List<SalaryProject> SalaryProjects { get; set; } = new List<SalaryProject>();
        public List<Enterprise> Enterprises { get; set; } = new List<Enterprise>(); 

    }
}
