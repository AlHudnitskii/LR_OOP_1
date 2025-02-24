using OOP_LR1.BankSystem.Core.Models;
using OOP_LR1.BankSystem.Core.Interfaces;

namespace OOP_LR1.BankSystem.Application.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void CreateAccount(Account account)
        {
            _accountRepository.AddAccount(account);
        }

        public Account GetAccount(string accountNumber)
        {
            return _accountRepository.GetAccountByNumber(accountNumber);
        }

        public void BlockAccount(string accountNumber)
        {
            var account = _accountRepository.GetAccountByNumber(accountNumber);
            if (account != null)
            {
                account.IsBlocked = true;
            }
        }
    }
}
