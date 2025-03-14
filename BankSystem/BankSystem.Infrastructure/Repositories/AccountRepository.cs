using OOP_LR1.BankSystem.Core.Models;
using OOP_LR1.BankSystem.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OOP_LR1.BankSystem.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankDbContext _context;

        public AccountRepository(BankDbContext context)
        {
            _context = context;
        }

        public void AddAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public Account GetAccountByNumber(string accountNumber)
        {
            return _context.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public IEnumerable<Account> GetAccountsByUserId(string userId)
        {
            return _context.Accounts.Where(a => a.OwnerId == userId).ToList();
        }

        public void Update(Account account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();
        }
    }
}