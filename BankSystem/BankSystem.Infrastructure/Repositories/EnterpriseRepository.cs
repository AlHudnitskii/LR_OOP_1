using OOP_LR1.BankSystem.Core.Interfaces;
using OOP_LR1.BankSystem.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace OOP_LR1.BankSystem.Infrastructure.Repositories
{
    public class EnterpriseRepository : IEnterpriseRepository
    {
        private readonly BankDbContext _context;

        public EnterpriseRepository(BankDbContext context)
        {
            _context = context;
        }

        public async Task<Enterprise> GetEnterpriseByIdAsync(string id)
        {
            return await _context.Enterprises.FindAsync(id);
        }

        public async Task<IEnumerable<Enterprise>> GetAllEnterprisesAsync()
        {
            return await _context.Enterprises.ToListAsync();
        }

        public async Task AddEnterpriseAsync(Enterprise enterprise)
        {
            await _context.Enterprises.AddAsync(enterprise);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEnterpriseAsync(Enterprise enterprise)
        {
            _context.Enterprises.Update(enterprise);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEnterpriseAsync(string id)
        {
            var enterprise = await _context.Enterprises.FindAsync(id);
            if (enterprise != null)
            {
                _context.Enterprises.Remove(enterprise);
                await _context.SaveChangesAsync();
            }
        }
    }
}
