using OOP_LR1.BankSystem.Core.Interfaces;
using OOP_LR1.BankSystem.Core.Models;

namespace OOP_LR1.BankSystem.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<Account> _accounts = new List<Account>();
        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }

        public Account GetAccountByNumber(string accountNumber)
        {
            return _accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public List<Account> GetAllAccounts()
        {
            return _accounts;
        }
    }
}
