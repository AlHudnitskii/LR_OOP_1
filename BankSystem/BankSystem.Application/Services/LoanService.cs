using OOP_LR1.BankSystem.Core.Interfaces;
using OOP_LR1.BankSystem.Core.Models;
using OOP_LR1.BankSystem.Infrastructure.Logging;

namespace OOP_LR1.BankSystem.Application.Services
{
    public class LoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly Logger _logger;

        public LoanService(ILoanRepository loanRepository, Logger logger)
        {
            _loanRepository = loanRepository;
            _logger = logger;
        }

        public void IssueLoan(string userId, decimal amount, int termInMonths, decimal interestRate)
        {
            var loan = new Loan
            {
                UserId = userId,
                Amount = amount,
                InterestRate = interestRate,
                TermInMonths = termInMonths
            };

            _loanRepository.AddLoan(loan);
            _logger.Log($"Выдан кредит: Пользователь {userId}, Сумма {amount}, Срок {termInMonths} месяцев.");
        }

        public void RepayLoan(string loanId)
        {
            var loan = _loanRepository.GetLoanById(loanId);
            if (loan == null)
            {
                throw new Exception("Кредит не найден.");
            }

            loan.IsPaid = true;
            _loanRepository.UpdateLoan(loan);
            _logger.Log($"Кредит {loanId} погашен.");
        }
    }
}
