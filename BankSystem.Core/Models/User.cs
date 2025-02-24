﻿using System.ComponentModel.DataAnnotations;
using System.Data;

namespace OOP_LR1.BankSystem.Core.Models
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FullName { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentType { get; set; }
        public string Citizenship { get; set; }
        public string CountryOfResidence { get; set; }
        public string PhoneNumber { get; set; }
        public string Email {  get; set; }
        public Role Role { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();

    }
}
