using OOP_LR1.BankSystem.Core.Models;

namespace OOP_LR1.BankSystem.Core.Interfaces
{
    public interface ILoanRepository
    {
        void AddLoan(Loan loan);
        Loan GetLoanById(string loanId);
        List<Loan> GetLoansByUserId(string userId);
        void UpdateLoan(Loan loan);
    }
}
