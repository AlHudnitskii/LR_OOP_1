using OOP_LR1.BankSystem.Core.Models;

namespace OOP_LR1.BankSystem.Core.Interfaces
{
    public interface ISalaryProjectRepository
    {
        void AddSalaryProject(SalaryProject salaryProject);
        SalaryProject GetSalaryProjectById(string salaryProjectId);
        List<SalaryProject> GetSalaryProjectsByEnterpriseId(string enterpriseId);
        void UpdateSalaryProject(SalaryProject salaryProject);
    }
}
