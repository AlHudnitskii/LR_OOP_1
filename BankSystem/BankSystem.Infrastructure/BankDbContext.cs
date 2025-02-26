using Microsoft.EntityFrameworkCore;
using OOP_LR1.BankSystem.Core.Models;

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

        public BankDbContext() { }

        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=bank.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>()
                .HasMany(b => b.Users)
                .WithOne(u => u.Bank)
                .HasForeignKey(u => u.BankId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Accounts)
                .WithOne(a => a.Owner)
                .HasForeignKey(a => a.OwnerId);

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
                new Bank { Id = Guid.NewGuid().ToString(), Name = "Банк 1" },
                new Bank { Id = Guid.NewGuid().ToString(), Name = "Банк 2" },
                new Bank { Id = Guid.NewGuid().ToString(), Name = "Банк 3" }
            };

            modelBuilder.Entity<Bank>().HasData(banks);

            var enterprises = new List<Enterprise>();
            for (int i = 1; i <= 10; i++)
            {
                enterprises.Add(new Enterprise
                {
                    Id = Guid.NewGuid().ToString(),
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
                    Id = Guid.NewGuid().ToString(),
                    FullName = $"Клиент {i}",
                    DocumentNumber = $"{2000000000 + i}",
                    DocumentType = "Паспорт",
                    Citizenship = i % 2 == 0 ? "Россия" : "Беларусь", 
                    CountryOfResidence = i % 2 == 0 ? "Россия" : "Беларусь",
                    PhoneNumber = $"+7 900 {1000000 + i}",
                    Email = $"client{i}@example.com",
                    Role = Role.Client,
                    BankId = banks[i % 3].Id 
                });
            }
            modelBuilder.Entity<User>().HasData(users);

            var accounts = new List<Account>();
            var random = new Random();

            foreach (var user in users)
            {
                for (int j = 0; j < 2; j++) 
                {
                    accounts.Add(new Account
                    {
                        Id = Guid.NewGuid().ToString(),
                        AccountNumber = $"{30000000 + accounts.Count + 1}",
                        Balance = random.Next(500, 5000), 
                        IsBlocked = false,
                        OwnerId = user.Id,
                        BankId = user.BankId
                    });
                }
            }

            foreach (var enterprise in enterprises)
            {
                for (int j = 0; j < 3; j++) 
                {
                    accounts.Add(new Account
                    {
                        Id = Guid.NewGuid().ToString(),
                        AccountNumber = $"{4000000000 + accounts.Count + 1}",
                        Balance = random.Next(10000, 1000000),
                        IsBlocked = false,
                        OwnerId = enterprise.Id, 
                        BankId = enterprise.BankId
                    });
                }
            }
            modelBuilder.Entity<Account>().HasData(accounts);

        }
    }
}
