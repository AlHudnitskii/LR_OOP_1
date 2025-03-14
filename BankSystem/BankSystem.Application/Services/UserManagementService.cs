using OOP_LR1.BankSystem.Core.Models;
using OOP_LR1.BankSystem.Infrastructure;
using OOP_LR1.BankSystem.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_LR1.BankSystem.Application.Services
{
    public class UserManagementService
    {
        private readonly BankDbContext _context;
        private readonly ILogger _logger;

        public UserManagementService(BankDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public void DeleteUser(string userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                _logger.Log($"Пользователь {user.Email} удален администратором.", LogLevel.Info);
                Console.WriteLine("Пользователь успешно удален.");
            }
            else
            {
                _logger.Log($"Попытка удаления несуществующего пользователя с Id: {userId}.", LogLevel.Warning);
                Console.WriteLine("Пользователь не найден.");
            }
        }

        public void ChangeUserRole(string userId, Role newRole)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                var oldRole = user.Role;
                user.Role = newRole;
                _context.SaveChanges();
                _logger.Log($"Роль пользователя {user.Email} изменена с {oldRole} на {newRole}.", LogLevel.Info);
                Console.WriteLine("Роль пользователя успешно изменена.");
            }
            else
            {
                _logger.Log($"Попытка изменения роли несуществующего пользователя с Id: {userId}.", LogLevel.Warning);
                Console.WriteLine("Пользователь не найден.");
            }
        }

        public void CancelAllActions()
        {
            var transactions = _context.Transactions.ToList();
            foreach (var transaction in transactions)
            {
                transaction.IsCancelled = true;
            }
            _context.SaveChanges();
            _logger.Log("Все действия пользователей отменены.", LogLevel.Info);
            Console.WriteLine("Все действия пользователей отменены.");
        }
    }
}