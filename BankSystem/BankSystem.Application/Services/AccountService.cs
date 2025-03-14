using OOP_LR1.BankSystem.Core.Models;
using OOP_LR1.BankSystem.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OOP_LR1.BankSystem.Infrastructure;
using OOP_LR1.BankSystem.Infrastructure.Logging;
namespace OOP_LR1.BankSystem.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger _logger;
        private readonly BankDbContext _context;

        public AccountService(IAccountRepository accountRepository, ILogger logger)
        {
            _accountRepository = accountRepository;
            _logger = logger; 
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
                _accountRepository.Update(account);
            }
        }

        public void UnblockAccount(string accountNumber)
        {
            var account = _accountRepository.GetAccountByNumber(accountNumber);
            if (account != null)
            {
                account.IsBlocked = false;
                _accountRepository.Update(account);
            }
        }

        public void ViewAccounts(string userId)
        {
            var accounts = _accountRepository.GetAccountsByUserId(userId);
            if (accounts.Any())
            {
                foreach (var account in accounts)
                {
                    Console.WriteLine($"Счет: {account.AccountNumber}, Баланс: {account.Balance}, Блокирован: {account.IsBlocked}");
                }
            }
            else
            {
                Console.WriteLine("У вас нет счетов.");
            }
        }

        public void ViewTransactionHistory(string accountNumber)
        {
            var transactions = _context.Transactions
                .Where(t => t.FromAccountId == accountNumber || t.ToAccountId == accountNumber)
                .OrderByDescending(t => t.Date)
                .ToList();

            foreach (var transaction in transactions)
            {
                Console.WriteLine($"[{transaction.Date}] Счет {transaction.FromAccountId} -> {transaction.ToAccountId}: {transaction.Amount}");
            }
        }
        public void CancelTransaction(string transactionId)
        {
            var transaction = _context.Transactions.FirstOrDefault(t => t.Id == transactionId);
            if (transaction != null)
            {
                var fromAccount = _context.Accounts.FirstOrDefault(a => a.Id == transaction.FromAccountId);
                var toAccount = _context.Accounts.FirstOrDefault(a => a.Id == transaction.ToAccountId);

                if (fromAccount != null && toAccount != null)
                {
                    fromAccount.Balance += transaction.Amount;
                    toAccount.Balance -= transaction.Amount;

                    _context.Transactions.Remove(transaction);
                    _context.SaveChanges();
                    _logger.Log($"Операция {transactionId} отменена.", LogLevel.Info);
                }
            }
        }

        public void FreezeAccount(string accountNumber)
        {
            var account = _accountRepository.GetAccountByNumber(accountNumber);
            if (account != null)
            {
                account.IsFrozen = true;
                _accountRepository.Update(account);
                _logger.Log($"Счет {accountNumber} заморожен.", LogLevel.Info);
            }
        }

        public void UnfreezeAccount(string accountNumber)
        {
            var account = _accountRepository.GetAccountByNumber(accountNumber);
            if (account != null)
            {
                account.IsFrozen = false;
                _accountRepository.Update(account);
                _logger.Log($"Счет {accountNumber} разморожен.", LogLevel.Info);
            }
        }

        public void TransferFunds(string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            var fromAccount = _accountRepository.GetAccountByNumber(fromAccountNumber);
            var toAccount = _accountRepository.GetAccountByNumber(toAccountNumber);

            if (fromAccount != null && toAccount != null)
            {
                if (fromAccount.Balance >= amount && !fromAccount.IsBlocked && !toAccount.IsBlocked)
                {
                    fromAccount.Balance -= amount;
                    toAccount.Balance += amount;

                    _accountRepository.Update(fromAccount);
                    _accountRepository.Update(toAccount);
                    Console.WriteLine("Перевод выполнен успешно.");
                }
                else
                {
                    Console.WriteLine("Недостаточно средств на счете или один из счетов заблокирован.");
                }
            }
            else
            {
                Console.WriteLine("Один из счетов не найден.");
            }
        }

        public void Deposit(string accountNumber, decimal amount)
        {
            var account = _accountRepository.GetAccountByNumber(accountNumber);
            if (account != null && !account.IsBlocked)
            {
                account.Balance += amount;
                _accountRepository.Update(account);
                Console.WriteLine("Средства успешно зачислены.");
            }
            else
            {
                Console.WriteLine("Счет не найден или заблокирован.");
            }
        }

        public void Withdraw(string accountNumber, decimal amount)
        {
            var account = _accountRepository.GetAccountByNumber(accountNumber);
            if (account != null && !account.IsBlocked && account.Balance >= amount)
            {
                account.Balance -= amount;
                _accountRepository.Update(account);
                Console.WriteLine("Средства успешно сняты.");
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счете или счет заблокирован.");
            }
        }

        public void CancelEnterpriseTransaction(string transactionId)
        {
            var transaction = _context.Transactions.FirstOrDefault(t => t.Id == transactionId);
            if (transaction != null)
            {
                transaction.IsCancelled = true;
                _context.SaveChanges();
                _logger.Log($"Операция {transactionId} отменена.", LogLevel.Info);
                Console.WriteLine("Операция отменена.");
            }
            else
            {
                Console.WriteLine("Операция не может быть отменена: это не операция специалиста предприятия.");
            }
        }
    }
}