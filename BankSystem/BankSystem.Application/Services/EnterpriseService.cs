using OOP_LR1.BankSystem.Core.Models;
using OOP_LR1.BankSystem.Core.Interfaces;

namespace OOP_LR1.BankSystem.Application.Services
{
    public class EnterpriseService
    {
        private readonly IEnterpriseRepository _enterpriseRepository;

        public EnterpriseService(IEnterpriseRepository enterpriseRepository)
        {
            _enterpriseRepository = enterpriseRepository;
        }

        public async Task<Enterprise> GetEnterpriseByIdAsync(string id)
        {
            return await _enterpriseRepository.GetEnterpriseByIdAsync(id);
        }

        public async Task<IEnumerable<Enterprise>> GetAllEnterprisesAsync()
        {
            return await _enterpriseRepository.GetAllEnterprisesAsync();
        }

        public async Task AddEnterpriseAsync(Enterprise enterprise)
        {
            await _enterpriseRepository.AddEnterpriseAsync(enterprise);
        }

        public async Task UpdateEnterpriseAsync(Enterprise enterprise)
        {
            await _enterpriseRepository.UpdateEnterpriseAsync(enterprise);
        }

        public async Task DeleteEnterpriseAsync(string id)
        {
            await _enterpriseRepository.DeleteEnterpriseAsync(id);
        }
    }
}
