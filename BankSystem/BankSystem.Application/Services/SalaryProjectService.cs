using OOP_LR1.BankSystem.Core.Models;
using OOP_LR1.BankSystem.Infrastructure;
using OOP_LR1.BankSystem.Infrastructure.Logging;
using System;
using System.Linq;

namespace OOP_LR1.BankSystem.Application.Services
{
    public class SalaryProjectService
    {
        private readonly BankDbContext _context;
        private readonly ILogger _logger;

        public SalaryProjectService(BankDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public void SubmitSalaryProject(string enterpriseId, string bankId, string specialistId)
        {
            var salaryProject = new SalaryProject
            {
                EnterpriseId = enterpriseId,
                BankId = bankId,
                StartDate = DateTime.UtcNow,
                IsActive = true
            };

            _context.SalaryProjects.Add(salaryProject);
            _context.SaveChanges();
            _logger.Log($"Специалист {specialistId} подал документы на зарплатный проект для предприятия {enterpriseId} в банке {bankId}.", LogLevel.Info);
        }

        public void ApproveSalaryProject(string projectId)
        {
            var project = _context.SalaryProjects.FirstOrDefault(sp => sp.Id == projectId);
            if (project != null)
            {
                project.IsActive = true; 
                _context.SaveChanges();
                _logger.Log($"Зарплатный проект {projectId} подтвержден.", LogLevel.Info);
            }
            else
            {
                _logger.Log($"Попытка подтверждения несуществующего зарплатного проекта {projectId}.", LogLevel.Warning);
            }
        }

        public void ViewSalaryProjects(string enterpriseId)
        {
            var projects = _context.SalaryProjects
                .Where(sp => sp.EnterpriseId == enterpriseId)
                .ToList();

            if (projects.Any())
            {
                foreach (var project in projects)
                {
                    Console.WriteLine($"Проект: {project.Id}, Банк: {project.BankId}, Дата начала: {project.StartDate}, Активен: {project.IsActive}");
                }
            }
            else
            {
                Console.WriteLine("Зарплатные проекты отсутствуют.");
            }
        }

        public void DeactivateSalaryProject(string projectId)
        {
            var project = _context.SalaryProjects.FirstOrDefault(sp => sp.Id == projectId);
            if (project != null)
            {
                project.IsActive = false;
                _context.SaveChanges();

                _logger.Log($"Зарплатный проект {projectId} деактивирован.", LogLevel.Info);
                Console.WriteLine("Зарплатный проект деактивирован.");
            }
            else
            {
                _logger.Log($"Попытка деактивации несуществующего зарплатного проекта {projectId}.", LogLevel.Warning);
                Console.WriteLine("Зарплатный проект не найден.");
            }
        }
    }
}