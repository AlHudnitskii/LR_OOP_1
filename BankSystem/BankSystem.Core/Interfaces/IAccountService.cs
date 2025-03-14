using OOP_LR1.BankSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LR1.BankSystem.Core.Interfaces
{
    public interface IAccountService
    {
        void CreateAccount(Account account);
        Account GetAccount(string accountNumber);
        void BlockAccount(string accountNumber);
        void UnblockAccount(string accountNumber);
        void ViewAccounts(string userId);
        void TransferFunds(string fromAccountNumber, string toAccountNumber, decimal amount);
        void Deposit(string accountNumber, decimal amount);
        void Withdraw(string accountNumber, decimal amount);
    }
}
