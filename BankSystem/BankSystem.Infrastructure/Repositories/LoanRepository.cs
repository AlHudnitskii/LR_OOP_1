using OOP_LR1.BankSystem.Core.Interfaces;
using OOP_LR1.BankSystem.Core.Models;

namespace OOP_LR1.BankSystem.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly List<Loan> _loans = new List<Loan>();

        public void AddLoan(Loan loan)
        {
            _loans.Add(loan);
        }

        public Loan GetLoanById(string loanId)
        {
            return _loans.FirstOrDefault(l => l.Id == loanId);
        }

        public List<Loan> GetLoansByUserId(string userId)
        {
            return _loans.Where(l => l.UserId == userId).ToList();
        }

        public void UpdateLoan(Loan loan)
        {
            var existingLoan = _loans.FirstOrDefault(l => l.Id == loan.Id);
            if (existingLoan != null)
            {
                existingLoan.Amount = loan.Amount;
                existingLoan.InterestRate = loan.InterestRate;
                existingLoan.TermInMonths = loan.TermInMonths;
                existingLoan.IsPaid = loan.IsPaid;
            }
        }
    }
}
