using Microsoft.EntityFrameworkCore;
using OOP_LR1.BankSystem.Core.Interfaces;
using OOP_LR1.BankSystem.Core.Models;
using OOP_LR1.BankSystem.Infrastructure;
using OOP_LR1.BankSystem.Infrastructure.Logging;
public class LoanService
{
    private readonly ILoanRepository _loanRepository;
    private readonly ILogger _logger;
    private readonly BankDbContext _context;


    public LoanService(ILoanRepository loanRepository, ILogger logger)
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
            TermInMonths = termInMonths,
            IsApproved = false, 
            IsPaid = false
        };

        _loanRepository.AddLoan(loan);
        _logger.Log($"Выдан кредит: Пользователь {userId}, Сумма {amount}, Срок {termInMonths} месяцев.", LogLevel.Info);
    }

    public void RepayLoan(string loanId)
    {
        var loan = _loanRepository.GetLoanById(loanId);
        if (loan == null)
        {
            _logger.Log($"Попытка погашения несуществующего кредита {loanId}.", LogLevel.Warning);
            throw new ArgumentException("Кредит не найден.");
        }

        loan.IsPaid = true;
        _loanRepository.UpdateLoan(loan);
        _logger.Log($"Кредит {loanId} погашен.", LogLevel.Info);
    }

    public IEnumerable<Loan> GetLoansByUserId(string userId)
    {
        var loans = _loanRepository.GetLoansByUserId(userId);
        if (loans == null || !loans.Any())
        {
            throw new ArgumentException("У пользователя нет кредитов.");
        }

        return loans;
    }

    public void ApproveLoan(string loanId)
    {
        var loan = _loanRepository.GetLoanById(loanId);
        if (loan == null)
        {
            throw new ArgumentException("Кредит с указанным Id не найден.");
        }

        loan.IsApproved = true;
        _loanRepository.UpdateLoan(loan);
    }
}