using OOP_LR1.BankSystem.Core.Interfaces;
using OOP_LR1.BankSystem.Core.Models;
using OOP_LR1.BankSystem.Infrastructure.Logging;

namespace OOP_LR1.BankSystem.Application.Services
{
    public class SalaryProjectService
    {
        private readonly ISalaryProjectRepository _salaryProjectRepository;
        private readonly Logger _logger;

        public SalaryProjectService(ISalaryProjectRepository salaryProjectRepository, Logger logger)
        {
            _salaryProjectRepository = salaryProjectRepository;
            _logger = logger;
        }

        public void CreateSalaryProject(string enterpriseId, string bankId)
        {
            var salaryProject = new SalaryProject
            {
                EnterpriseId = enterpriseId,
                BankId = bankId
            };

            _salaryProjectRepository.AddSalaryProject(salaryProject);
            _logger.Log($"Создан зарплатный проект: Предприятие {enterpriseId}, Банк {bankId}.");
        }

        public void DeactivateSalaryProject(string salaryProjectId)
        {
            var salaryProject = _salaryProjectRepository.GetSalaryProjectById(salaryProjectId);
            if (salaryProject == null)
            {
                throw new Exception("Зарплатный проект не найден.");
            }

            salaryProject.IsActive = false;
            _salaryProjectRepository.UpdateSalaryProject(salaryProject);
            _logger.Log($"Зарплатный проект {salaryProjectId} деактивирован.");
        }
    }
}
