using OOP_LR1.BankSystem.Core.Models;
using OOP_LR1.BankSystem.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace OOP_LR1.BankSystem.Application.Services
{
    public class BankService
    {
        private readonly BankDbContext _context;

        public BankService(BankDbContext context)
        {
            _context = context;
        }

        public List<Bank> GetAllBanks()
        {
            return _context.Banks.ToList();
        }

        public Bank GetBankById(string bankId)
        {
            return _context.Banks.FirstOrDefault(b => b.Id == bankId);
        }

        public void AddBank(Bank bank)
        {
            _context.Banks.Add(bank);
            _context.SaveChanges();
        }

        public void DeleteBank(string bankId)
        {
            var bank = _context.Banks.FirstOrDefault(b => b.Id == bankId);
            if (bank != null)
            {
                _context.Banks.Remove(bank);
                _context.SaveChanges();
            }
        }
    }
}