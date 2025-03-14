using OOP_LR1.BankSystem.Application.Services;
using OOP_LR1.BankSystem.Core.Models;
using OOP_LR1.BankSystem.Infrastructure;
using OOP_LR1.BankSystem.Infrastructure.Logging;
using OOP_LR1.BankSystem.Infrastructure.Repositories;
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
        private readonly ILogger _logger;

        public MenuManager(AuthManager authManager, UserManager userManager, ILogger logger)
        {
            _authManager = authManager;
            _userManager = userManager;
            _logger = logger;
        }

        public Bank SelectBank(BankDbContext context)
        {
            var banks = context.Banks.ToList();
            if (banks == null || !banks.Any())
            {
                Console.WriteLine("Банки не найдены.");
                return null;
            }

            string[] headers = { "Номер", "Название банка" };
            var rows = banks.Select((bank, index) => new[] { (index + 1).ToString(), bank.Name }).ToList();

            Console.WriteLine("Выберите банк:");
            TableDrawer.DrawTable(headers, rows);

            while (true)
            {
                Console.Write("Ваш выбор: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= banks.Count)
                {
                    return banks[choice - 1];
                }
                else
                {
                    Console.WriteLine("Неверный выбор. Пожалуйста, введите число от 1 до " + banks.Count + ".");
                }
            }
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
                new[] { "6", "Выбрать другой банк" },
                new[] { "7", "Выйти из программы" }
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
                        ShowRoleMenu(user, context);
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
                    var newBank = SelectBank(context);
                    if (newBank != null)
                    {
                        _authManager.UpdateUserBank(context, newBank.Id);
                        Console.WriteLine($"Выбран банк: {newBank.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Не удалось выбрать банк.");
                    }
                    break;
                case "7":
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

        public void ShowRoleMenu(User user, BankDbContext context)
        {
            while (true)
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
                        return;
                }

                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();

                bool shouldExit = HandleRoleChoice(choice, user, context);

                if (shouldExit)
                {
                    return; 
                }
            }
        }

        public bool HandleRoleChoice(string choice, User user, BankDbContext context)
        {
            switch (user.Role)
            {
                case Role.Client:
                    return HandleClientChoice(choice, context);
                case Role.Operator:
                    return HandleOperatorChoice(choice, context);
                case Role.Manager:
                    return HandleManagerChoice(choice, context);
                case Role.EnterpriseSpecialist:
                    return HandleEnterpriseSpecialistChoice(choice, context);
                case Role.Administrator:
                    return HandleAdminChoice(choice, context);
                default:
                    Console.WriteLine("Неверный выбор.");
                    return false; 
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
                new[] { "4", "Погасить кредит" },
                new[] { "5", "Просмотр кредитов" },
                new[] { "6", "Снять деньги со счета" },
                new[] { "7", "Блокировка счета" },
                new[] { "8", "Выйти" }
            };

            TableDrawer.DrawTable(headers, rows);
        }

        private bool HandleClientChoice(string choice, BankDbContext context)
        {
            var accountService = new AccountService(new AccountRepository(context), _logger);
            var loanService = new LoanService(new LoanRepository(context), _logger);

            switch (choice)
            {
                case "1":
                    accountService.ViewAccounts(_authManager.CurrentUser.Id);
                    break;

                case "2":
                    Console.Write("Введите номер счета отправителя: ");
                    string fromAccountNumber = Console.ReadLine();
                    Console.Write("Введите номер счета получателя: ");
                    string toAccountNumber = Console.ReadLine();
                    Console.Write("Введите сумму для перевода: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                    {
                        var fromAccount = accountService.GetAccount(fromAccountNumber);
                        var toAccount = accountService.GetAccount(toAccountNumber);

                        if (fromAccount != null && toAccount != null)
                        {
                            if (fromAccount.Balance >= amount)
                            {
                                accountService.TransferFunds(fromAccountNumber, toAccountNumber, amount);
                                Console.WriteLine("Перевод выполнен успешно.");
                            }
                            else
                            {
                                Console.WriteLine("Недостаточно средств на счете отправителя.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Один из счетов не найден.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверная сумма.");
                    }
                    break;

                case "3":
                    Console.Write("Введите сумму кредита: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal loanAmount))
                    {
                        Console.Write("Введите срок кредита (в месяцах): ");
                        if (int.TryParse(Console.ReadLine(), out int termInMonths))
                        {
                            decimal interestRate = termInMonths switch
                            {
                                <= 3 => 0.05m,
                                <= 6 => 0.1m,
                                <= 12 => 0.15m,
                                <= 24 => 0.2m,
                                _ => 0.25m
                            };

                            loanService.IssueLoan(_authManager.CurrentUser.Id, loanAmount, termInMonths, interestRate);
                            Console.WriteLine("Заявка на кредит подана.");
                        }
                        else
                        {
                            Console.WriteLine("Неверный срок кредита.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверная сумма кредита.");
                    }
                    break;

                case "4":
                    Console.Write("Введите Id кредита: ");
                    string loanId = Console.ReadLine();
                    try
                    {
                        loanService.RepayLoan(loanId);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Произошла ошибка: " + ex.Message);
                    }
                    break;

                case "5":
                    try
                    {
                        var loans = loanService.GetLoansByUserId(_authManager.CurrentUser.Id);
                        foreach (var loan in loans)
                        {
                            Console.WriteLine($"Кредит: {loan.Id}, Сумма: {loan.Amount}, Срок: {loan.TermInMonths} месяцев, Статус: {(loan.IsPaid ? "Погашен" : "Не погашен")}");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Произошла ошибка: " + ex.Message);
                    }
                    break;

                case "6":
                    Console.Write("Введите номер счета: ");
                    string accountNumber = Console.ReadLine();
                    Console.Write("Введите сумму для снятия: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                    {
                        var account = accountService.GetAccount(accountNumber);
                        if (account != null)
                        {
                            if (account.Balance >= withdrawAmount)
                            {
                                accountService.Withdraw(accountNumber, withdrawAmount);
                                Console.WriteLine("Средства успешно сняты.");
                            }
                            else
                            {
                                Console.WriteLine("Недостаточно средств на счете.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Счет не найден.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверная сумма.");
                    }
                    break;

                case "7":
                    try
                    {
                        Console.Write("Введите номер счета: ");
                        string accountNumberToBlock = Console.ReadLine();
                        accountService.BlockAccount(accountNumberToBlock);
                        Console.WriteLine("Счет заблокирован.");
                    }
                    catch (Exception)
                    {
                        Console.Write("Введены некорректные данные.\n");
                    }
                    break;

                case "8":
                    _authManager.LogoutUser();
                    return true;

                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
            return false;
        }

        private void ShowOperatorMenu()
        {
            string[] headers = { "Номер", "Действие" };
            var rows = new List<string[]>
            {
                new[] { "1", "Просмотр статистики по счету" },
                new[] { "2", "Отмена операции" },
                new[] { "3", "Подтвердить зарплатный проект" },
                new[] { "4", "Выйти" }
            };

            TableDrawer.DrawTable(headers, rows);
        }

        private bool HandleOperatorChoice(string choice, BankDbContext context)
        {
            var accountService = new AccountService(new AccountRepository(context), _logger);
            var salaryProjectService = new SalaryProjectService(context, _logger);

            switch (choice)
            {
                case "1":
                    try
                    {
                        Console.Write("Введите номер счета: ");
                        string accountNumber = Console.ReadLine();
                        accountService.ViewTransactionHistory(accountNumber);
                    }
                    catch (Exception)
                    {
                        Console.Write("Введены некорректные данные.\n");
                    }
                    break;

                case "2":
                    try
                    {
                        Console.Write("Введите Id операции: ");
                        string transactionId = Console.ReadLine();
                        accountService.CancelTransaction(transactionId);
                    }
                    catch (Exception)
                    {
                        Console.Write("Введены некорректные данные.\n");
                    }
                    break;

                case "3":
                    try
                    {
                        Console.Write("Введите Id зарплатного проекта: ");
                        string projectId = Console.ReadLine();
                        salaryProjectService.ApproveSalaryProject(projectId);
                    }
                    catch (Exception)
                    {
                        Console.Write("Введены некорректные данные.\n");
                    }
                    break;

                case "4":
                    _authManager.LogoutUser();
                    return true;
                    break;

                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
            return false;
        }

        private void ShowManagerMenu()
        {
            string[] headers = { "Номер", "Действие" };
            var rows = new List<string[]>
            {
                new[] { "1", "Подтвердить кредит" },
                new[] { "2", "Подтвердить зарплатный проект" },
                new[] { "3", "Отмена операций специалиста" },
                new[] { "4", "Выйти" }
            };

            TableDrawer.DrawTable(headers, rows);
        }

        private bool HandleManagerChoice(string choice, BankDbContext context)
        {
            var loanService = new LoanService(new LoanRepository(context), _logger);
            var salaryProjectService = new SalaryProjectService(context, _logger);
            var accountService = new AccountService(new AccountRepository(context), _logger);

            switch (choice)
            {
                case "1":
                    try
                    {
                        Console.Write("Введите Id кредита: ");
                        string loanId = Console.ReadLine();
                        loanService.ApproveLoan(loanId);
                    }
                    catch (Exception)
                    {
                        Console.Write("Введены некорректные данные.\n");
                    }
                    break;

                case "2":
                    try
                    {
                        Console.Write("Введите Id зарплатного проекта: ");
                        string projectId = Console.ReadLine();
                        salaryProjectService.ApproveSalaryProject(projectId);
                    }
                    catch(Exception)
                    {
                        Console.Write("Введены некорректные данные.\n");
                    }
                    break;

                case "3":
                    try
                    {
                        Console.Write("Введите Id операции: ");
                        string transactionId = Console.ReadLine();
                        accountService.CancelEnterpriseTransaction(transactionId);
                    }
                    catch (Exception)
                    {
                        Console.Write("Введены некорректные данные.\n");
                    }
                    break;

                case "4":
                    _authManager.LogoutUser();
                    return true;
                    break;

                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
            return false;
        }

        private void ShowEnterpriseSpecialistMenu()
        {
            string[] headers = { "Номер", "Действие" };
            var rows = new List<string[]>
            {
                new[] { "1", "Подать документы на зарплатный проект" },
                new[] { "2", "Просмотр зарплатных проектов" },
                new[] { "3", "Деактивировать зарплатный проект" },
                new[] { "4", "Запрос на перевод средств" },
                new[] { "5", "Выйти" }
            };

            TableDrawer.DrawTable(headers, rows);
        }

        private bool HandleEnterpriseSpecialistChoice(string choice, BankDbContext context)
        {
            var salaryProjectService = new SalaryProjectService(context, _logger);
            var accountService = new AccountService(new AccountRepository(context), _logger);

            switch (choice)
            {
                case "1":
                    Console.Write("Введите Id предприятия: ");
                    string enterpriseId = Console.ReadLine();
                    Console.Write("Введите Id банка: ");
                    string bankId = Console.ReadLine();

                    if (string.IsNullOrEmpty(enterpriseId) || string.IsNullOrEmpty(bankId))
                    {
                        Console.WriteLine("Id предприятия и банка не могут быть пустыми.");
                        break;
                    }

                    salaryProjectService.SubmitSalaryProject(enterpriseId, bankId, _authManager.CurrentUser.Id);
                    break;

                case "2":
                    Console.Write("Введите Id предприятия: ");
                    string enterpriseIdForView = Console.ReadLine();
                    salaryProjectService.ViewSalaryProjects(enterpriseIdForView);
                    break;

                case "3":
                    Console.Write("Введите Id зарплатного проекта: ");
                    string projectId = Console.ReadLine();
                    salaryProjectService.DeactivateSalaryProject(projectId);
                    break;

                case "4":
                    Console.Write("Введите номер счета отправителя: ");
                    string fromAccountNumber = Console.ReadLine();
                    Console.Write("Введите номер счета получателя: ");
                    string toAccountNumber = Console.ReadLine();
                    Console.Write("Введите сумму для перевода: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                    {
                        accountService.TransferFunds(fromAccountNumber, toAccountNumber, amount);
                    }
                    else
                    {
                        Console.WriteLine("Неверная сумма.");
                    }
                    break;

                case "5":
                    _authManager.LogoutUser();
                    return true;
                    break;

                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
            return false;
        }

        private void ShowAdminMenu()
        {
            string[] headers = { "Номер", "Действие" };
            var rows = new List<string[]>
            {
                new[] { "1", "Просмотр логов" },
                new[] { "2", "Управление пользователями" },
                new[] { "3", "Отмена всех действий" },
                new[] { "4", "Выйти" }
            };

            TableDrawer.DrawTable(headers, rows);
        }

        private bool HandleAdminChoice(string choice, BankDbContext context)
        {
            var userManagementService = new UserManagementService(context, _logger);
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Последние логи:");
                    var logFilePath = "logs.txt";
                    if (File.Exists(logFilePath))
                    {
                        var logs = File.ReadAllLines(logFilePath);
                        foreach (var log in logs)
                        {
                            Console.WriteLine(log);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Логи отсутствуют.");
                    }
                    break;

                case "2":
                    Console.WriteLine("1. Показать всех пользователей");
                    Console.WriteLine("2. Удалить пользователя");
                    Console.WriteLine("3. Изменить роль пользователя");
                    Console.Write("Ваш выбор: ");
                    string userAction = Console.ReadLine();

                    switch (userAction)
                    {
                        case "1":
                            var users = userManagementService.GetAllUsers();
                            foreach (var user in users)
                            {
                                Console.WriteLine($"{user.FullName} ({user.Role})");
                            }
                            break;

                        case "2":
                            Console.Write("Введите Id пользователя для удаления: ");
                            string userIdToDelete = Console.ReadLine();
                            userManagementService.DeleteUser(userIdToDelete);
                            break;

                        case "3":
                            Console.Write("Введите Id пользователя: ");
                            string userIdToChange = Console.ReadLine();
                            Console.WriteLine("Выберите новую роль:");
                            Console.WriteLine("1. Клиент");
                            Console.WriteLine("2. Оператор");
                            Console.WriteLine("3. Менеджер");
                            Console.WriteLine("4. Специалист стороннего предприятия");
                            Console.WriteLine("5. Администратор");
                            Console.Write("Ваш выбор: ");
                            string roleChoice = Console.ReadLine();

                            Role newRole = roleChoice switch
                            {
                                "1" => Role.Client,
                                "2" => Role.Operator,
                                "3" => Role.Manager,
                                "4" => Role.EnterpriseSpecialist,
                                "5" => Role.Administrator,
                                _ => Role.Client
                            };

                            userManagementService.ChangeUserRole(userIdToChange, newRole);
                            break;

                        default:
                            Console.WriteLine("Неверный выбор.");
                            break;
                    }
                    break;

                case "3":
                    userManagementService.CancelAllActions();
                    break;

                case "4":
                    _authManager.LogoutUser();
                    return true;
                    break;

                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
            return false;
        }
    }
}