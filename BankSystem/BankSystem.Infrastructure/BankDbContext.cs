using Microsoft.EntityFrameworkCore;
using OOP_LR1.BankSystem.Core.Models;
using System.Xml.Linq;

namespace OOP_LR1.BankSystem.Infrastructure
{
    public class BankDbContext : DbContext
    {
        public DbSet<Bank> Banks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<SalaryProject> SalaryProjects { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\OOP_LR1\\BankSystem\\bank.db");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>()
                .HasMany(b => b.Users)
                .WithOne(u => u.Bank)
                .HasForeignKey(u => u.BankId);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Accounts)
                .WithOne(a => a.Owner)
                .HasForeignKey(a => a.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enterprise>()
                .HasMany(e => e.SalaryProjects)
                .WithOne(sp => sp.Enterprise)
                .HasForeignKey(sp => sp.EnterpriseId);

            modelBuilder.Entity<Bank>()
                .HasMany(b => b.SalaryProjects)
                .WithOne(sp => sp.Bank)
                .HasForeignKey(sp => sp.BankId);

            var banks = new List<Bank>
            {
                new Bank { Id = "1", Name = "Банк 1" },
                new Bank { Id = "2", Name = "Банк 2" },
                new Bank { Id = "3", Name = "Банк 3" }
            };
            modelBuilder.Entity<Bank>().HasData(banks);

            var enterprises = new List<Enterprise>();
            for (int i = 1; i <= 10; i++)
            {
                enterprises.Add(new Enterprise
                {
                    Id = i.ToString(),
                    Name = $"Предприятие {i}",
                    Type = i % 2 == 0 ? "ООО" : "ИП",
                    LegalAddress = $"ул. Пушкина {i}",
                    TaxNumber = $"{1000000000 + i}",
                    BankId = banks[i % 3].Id
                });
            }
            modelBuilder.Entity<Enterprise>().HasData(enterprises);

            var users = new List<User>();
            for (int i = 1; i <= 100; i++)
            {
                users.Add(new User
                {
                    Id = i.ToString(),
                    FullName = $"Клиент {i}",
                    DocumentNumber = $"{1111000000 + i}",
                    DocumentType = "Паспорт",
                    Citizenship = i % 2 == 0 ? "Россия" : "Беларусь",
                    CountryOfResidence = i % 2 == 0 ? "Россия" : "Беларусь",
                    PhoneNumber = $"+375 29 {1000000 + 20 * i}",
                    Email = $"client{i}@example.com",
                    Role = Role.Client,
                    BankId = banks[i % 3].Id
                });
            }
            modelBuilder.Entity<User>().HasData(users);

            var accounts = new List<Account>();
            int accountIdCounter = 1;

            foreach (var user in users)
            {
                for (int j = 0; j < 2; j++)
                {
                    accounts.Add(new Account
                    {
                        Id = accountIdCounter.ToString(),
                        AccountNumber = $"ACC{accountIdCounter}",
                        IsBlocked = false,
                        IsFrozen = false,
                        Balance = 1000,
                        OwnerId = user.Id.ToString(),
                        BankId = user.BankId
                    }); ;
                    accountIdCounter++;
                }
            }

            foreach (var enterprise in enterprises)
            {
                for (int j = 0; j < 3; j++)
                {   
                    accounts.Add(new Account
                    {
                        Id = accountIdCounter.ToString(),
                        AccountNumber = $"ACC{accountIdCounter}",
                        IsBlocked = false,
                        IsFrozen = false,
                        Balance = 5000,
                        OwnerId = enterprise.Id,
                        BankId = enterprise.BankId
                    });
                    accountIdCounter++;
                }
            }
            modelBuilder.Entity<Account>().HasData(accounts);
        }
    }
}
