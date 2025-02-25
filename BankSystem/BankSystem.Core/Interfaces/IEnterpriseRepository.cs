using OOP_LR1.BankSystem.Core.Models;

namespace OOP_LR1.BankSystem.Core.Interfaces
{
    public interface IEnterpriseRepository
    {
        Task<Enterprise> GetEnterpriseByIdAsync(string id);
        Task<IEnumerable<Enterprise>> GetAllEnterprisesAsync();
        Task AddEnterpriseAsync(Enterprise enterprise);
        Task UpdateEnterpriseAsync(Enterprise enterprise);
        Task DeleteEnterpriseAsync(string id);
    }
}
