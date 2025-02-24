using OOP_LR1.BankSystem.Core.Models;

namespace OOP_LR1.BankSystem.Core.Interfaces
{
    public interface IAccountRepository
    {
        void AddAccount(Account account);
        Account GetAccountByNumber(string accountNumber);
        List<Account> GetAllAccounts();
    }
}
