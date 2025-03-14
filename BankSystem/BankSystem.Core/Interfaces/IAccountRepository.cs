using OOP_LR1.BankSystem.Core.Models;
using System.Collections.Generic;

namespace OOP_LR1.BankSystem.Core.Interfaces
{
    public interface IAccountRepository
    {
        void AddAccount(Account account);
        Account GetAccountByNumber(string accountNumber);
        IEnumerable<Account> GetAccountsByUserId(string userId);
        void Update(Account account);
    }
}