using OOP_LR1.BankSystem.Core.Interfaces;
using OOP_LR1.BankSystem.Core.Models;

namespace OOP_LR1.BankSystem.Infrastructure.Repositories
{
    public class SalaryProjectRepository : ISalaryProjectRepository
    {
        private readonly List<SalaryProject> _salaryProjects = new List<SalaryProject>();

        public void AddSalaryProject(SalaryProject salaryProject)
        {
            _salaryProjects.Add(salaryProject);
        }

        public SalaryProject GetSalaryProjectById(string salaryProjectId)
        {
            return _salaryProjects.FirstOrDefault(sp => sp.Id == salaryProjectId);
        }

        public List<SalaryProject> GetSalaryProjectsByEnterpriseId(string enterpriseId)
        {
            return _salaryProjects.Where(sp => sp.EnterpriseId == enterpriseId).ToList();
        }

        public void UpdateSalaryProject(SalaryProject salaryProject)
        {
            var existingSalaryProject = _salaryProjects.FirstOrDefault(sp => sp.Id == salaryProject.Id);
            if (existingSalaryProject != null)
            {
                existingSalaryProject.EnterpriseId = salaryProject.EnterpriseId;
                existingSalaryProject.BankId = salaryProject.BankId;
                existingSalaryProject.IsActive = salaryProject.IsActive;
            }
        }
    }
}
