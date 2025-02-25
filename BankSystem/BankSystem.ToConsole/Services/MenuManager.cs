using OOP_LR1.BankSystem.Application.Services;
using OOP_LR1.BankSystem.Core.Models;
using OOP_LR1.BankSystem.Infrastructure;
using OOP_LR1.BankSystem.ToConsole.Style;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_LR1.BankSystem.ToConsole.Services
{
    public class MenuManager
    {
        private readonly AuthManager _authManager;
        private readonly UserManager _userManager;

        public MenuManager(AuthManager authManager, UserManager userManager)
        {
            _authManager = authManager;
            _userManager = userManager;
        }

        public Bank SelectBank(BankDbContext context)
        {
            var banks = context.Banks.ToList();
            Console.WriteLine("Выберите банк:");
            for (int i = 0; i < banks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {banks[i].Name}");
            }

            int choice = int.Parse(Console.ReadLine());
            return banks[choice - 1];
        }

        public void ShowMainMenu()
        {
            string[] headers = { "Номер", "Действие" };
            var rows = new List<string[]>
            {
                new[] { "1", "Регистрация" },
                new[] { "2", "Вход" },
                new[] { "3", "Показать всех пользователей" },
                new[] { "4", "Выход" },
                new[] { "5", "Показать текущего пользователя" },
                new[] { "6", "Выйти из программы" }
            };

            TableDrawer.DrawTable(headers, rows);
        }

        public void HandleChoice(string choice, BankDbContext context)
        {
            switch (choice)
            {
                case "1":
                    _authManager.RegisterUser(context, _authManager.CurrentUser?.BankId);
                    break;
                case "2":
                    var user = _authManager.Authenticate(context, _authManager.CurrentUser?.BankId);
                    if (user != null)
                    {
                        ShowRoleMenu(user);
                    }
                    break;
                case "3":
                    _userManager.ShowAllUsers();
                    break;
                case "4":
                    _authManager.LogoutUser();
                    break;
                case "5":
                    ShowCurrentUser();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }

        public void ShowCurrentUser()
        {
            var currentUser = _authManager.CurrentUser;
            if (currentUser != null)
            {
                Console.WriteLine($"Текущий пользователь: {currentUser.FullName} ({currentUser.Role})");
            }
            else
            {
                Console.WriteLine("Вы не вошли в систему.");
            }
        }

        public void ShowRoleMenu(User user)
        {
            switch (user.Role)
            {
                case Role.Client:
                    ShowClientMenu();
                    break;
                case Role.Operator:
                    ShowOperatorMenu();
                    break;
                case Role.Manager:
                    ShowManagerMenu();
                    break;
                case Role.EnterpriseSpecialist:
                    ShowEnterpriseSpecialistMenu();
                    break;
                case Role.Administrator:
                    ShowAdminMenu();
                    break;
                default:
                    Console.WriteLine("Роль не определена.");
                    break;
            }
        }

        public void HandleRoleChoice(string choice, User user, BankDbContext context)
        {
            switch (user.Role)
            {
                case Role.Client:
                    HandleClientChoice(choice, context);
                    break;
                case Role.Operator:
                    HandleOperatorChoice(choice, context);
                    break;
                case Role.Manager:
                    HandleManagerChoice(choice, context);
                    break;
                case Role.EnterpriseSpecialist:
                    HandleEnterpriseSpecialistChoice(choice, context);
                    break;
                case Role.Administrator:
                    HandleAdminChoice(choice, context);
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }

        private void ShowClientMenu()
        {
            string[] headers = { "Номер", "Действие" };
            var rows = new List<string[]>
            {
                new[] { "1", "Просмотр счетов" },
                new[] { "2", "Перевод средств" },
                new[] { "3", "Подать заявку на кредит" },
                new[] { "4", "Подать заявку на зарплатный проект" },
                new[] { "5", "Выйти" }
            };

            TableDrawer.DrawTable(headers, rows);
        }

        private void HandleClientChoice(string choice, BankDbContext context)
        {
            switch (choice)
            {
                case "1":
                    var accounts = context.Accounts.Where(a => a.OwnerId == _authManager.CurrentUser.Id).ToList();
                    foreach (var account in accounts)
                    {
                        Console.WriteLine($"Счет: {account.AccountNumber}, Баланс: {account.Balance}");
                    }
                    break;
                case "2":
                    Console.WriteLine("Перевод средств...");
                    break;
                case "3":
                    Console.WriteLine("Подача заявки на кредит...");
                    break;
                case "4":
                    Console.WriteLine("Подача заявки на зарплатный проект...");
                    break;
                case "5":
                    _authManager.LogoutUser();
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }

        private void ShowOperatorMenu()
        {
            string[] headers = { "Номер", "Действие" };
            var rows = new List<string[]>
            {
                new[] { "1", "Просмотр всех счетов" },
                new[] { "2", "Отмена операции" },
                new[] { "3", "Выйти" }
            };

            TableDrawer.DrawTable(headers, rows);
        }

        private void HandleOperatorChoice(string choice, BankDbContext context)
        {
            switch (choice)
            {
                case "1":
                    var accounts = context.Accounts.ToList();
                    foreach (var account in accounts)
                    {
                        Console.WriteLine($"Счет: {account.AccountNumber}, Баланс: {account.Balance}");
                    }
                    break;
                case "2":
                    Console.WriteLine("Отмена операции...");
                    break;
                case "3":
                    _authManager.LogoutUser();
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }

        private void ShowManagerMenu()
        {
            string[] headers = { "Номер", "Действие" };
            var rows = new List<string[]>
            {
                new[] { "1", "Подтвердить кредит" },
                new[] { "2", "Подтвердить зарплатный проект" },
                new[] { "3", "Управление счетами предприятий" },
                new[] { "4", "Выйти" }
            };

            TableDrawer.DrawTable(headers, rows);
        }

        private void HandleManagerChoice(string choice, BankDbContext context)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Подтверждение кредита...");
                    break;
                case "2":
                    Console.WriteLine("Подтверждение зарплатного проекта...");
                    break;
                case "3":
                    Console.WriteLine("Управление счетами предприятий...");
                    break;
                case "4":
                    _authManager.LogoutUser();
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }

        private void ShowEnterpriseSpecialistMenu()
        {
            string[] headers = { "Номер", "Действие" };
            var rows = new List<string[]>
            {
                new[] { "1", "Подать документы на зарплатный проект" },
                new[] { "2", "Запрос на перевод средств" },
                new[] { "3", "Выйти" }
            };

            TableDrawer.DrawTable(headers, rows);
        }

        private void HandleEnterpriseSpecialistChoice(string choice, BankDbContext context)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Подача документов на зарплатный проект...");
                    break;
                case "2":
                    Console.WriteLine("Запрос на перевод средств...");
                    break;
                case "3":
                    _authManager.LogoutUser();
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }

        private void ShowAdminMenu()
        {
            string[] headers = { "Номер", "Действие" };
            var rows = new List<string[]>
            {
                new[] { "1", "Просмотр логов" },
                new[] { "2", "Управление пользователями" },
                new[] { "3", "Выйти" }
            };

            TableDrawer.DrawTable(headers, rows);
        }

        private void HandleAdminChoice(string choice, BankDbContext context)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Просмотр логов...");
                    break;
                case "2":
                    Console.WriteLine("Управление пользователями...");
                    break;
                case "3":
                    _authManager.LogoutUser();
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }
}