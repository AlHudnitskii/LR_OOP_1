using OOP_LR1.BankSystem.Application.Services;
using OOP_LR1.BankSystem.Core.Models;
using OOP_LR1.BankSystem.Infrastructure;
using OOP_LR1.BankSystem.Infrastructure.Logging;
using System.Globalization;

namespace OOP_LR1.BankSystem.ToConsole.Services
{
    public class AuthManager
    {
        private readonly AuthService _authService;
        private readonly UserService _userService;
        private readonly ILogger _logger;
        private User _currentUser;

        public AuthManager(AuthService authService, ILogger logger)
        {
            _authService = authService;
            _logger = logger;
        }

        public User CurrentUser => _currentUser;

        public void RegisterUser(BankDbContext context, string bankId)
        {
            Console.WriteLine("Регистрация нового пользователя");

            string fullName;
            do
            {
                Console.Write("Введите ФИО: ");
                fullName = Console.ReadLine();
                if (!UserValidator.ValidateFullName(fullName))
                {
                    Console.WriteLine("Некорректное ФИО. Используйте только буквы английского алфавита и пробелы.");
                }
            } while (!UserValidator.ValidateFullName(fullName));

            string documentNumber;
            do
            {
                Console.Write("Введите номер документа (9 цифр): ");
                documentNumber = Console.ReadLine();
                if (!UserValidator.ValidateDocumentNumber(documentNumber))
                {
                    Console.WriteLine("Некорректный номер документа. Введите 9 цифр.");
                }
            } while (!UserValidator.ValidateDocumentNumber(documentNumber));

            string documentType = UserValidator.SelectDocumentType();

            string citizenship;
            do
            {
                Console.Write("Введите гражданство: ");
                citizenship = Console.ReadLine();
                if (!UserValidator.ValidateCitizenship(citizenship))
                {
                    Console.WriteLine("Некорректное гражданство. Используйте только буквы английского алфавита.");
                }
            } while (!UserValidator.ValidateCitizenship(citizenship));

            string countryOfResidence;
            do
            {
                Console.Write("Введите страну проживания: ");
                countryOfResidence = Console.ReadLine();
                if (!UserValidator.ValidateCountryOfResidence(countryOfResidence))
                {
                    Console.WriteLine("Некорректная страна проживания. Используйте только буквы  английского алфавита.");
                }
            } while (!UserValidator.ValidateCountryOfResidence(countryOfResidence));

            string phoneNumber;
            do
            {
                Console.Write("Введите номер телефона в формате +XXXXXXXXXXXX (от 7 до 15 цифр): ");
                phoneNumber = Console.ReadLine();
                if (!UserValidator.ValidatePhoneNumber(phoneNumber))
                {
                    Console.WriteLine("Некорректный номер телефона. Введите в формате +XXXXXXXXXXXX (от 7 до 15 цифр).");
                }
            } while (!UserValidator.ValidatePhoneNumber(phoneNumber));

            string email;
            do
            {
                Console.Write("Введите email: ");
                email = Console.ReadLine();
                if (!UserValidator.ValidateEmail(email))
                {
                    Console.WriteLine("Некорректный email. Введите в формате example@example.com.");
                }
            } while (!UserValidator.ValidateEmail(email));

            Console.WriteLine("Выберите роль:");
            Console.WriteLine("1. Клиент");
            Console.WriteLine("2. Оператор");
            Console.WriteLine("3. Менеджер");
            Console.WriteLine("4. Специалист стороннего предприятия");
            Console.WriteLine("5. Администратор");
            Console.Write("Ваш выбор: ");
            string roleChoice = Console.ReadLine();

            Role role = roleChoice switch
            {
                "1" => Role.Client,
                "2" => Role.Operator,
                "3" => Role.Manager,
                "4" => Role.EnterpriseSpecialist,
                "5" => Role.Administrator,
                _ => Role.Client
            };

            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                FullName = fullName,
                DocumentNumber = documentNumber,
                DocumentType = documentType,
                Citizenship = citizenship,
                CountryOfResidence = countryOfResidence,
                PhoneNumber = phoneNumber,
                Email = email,
                Role = role,
                BankId = bankId,
                IsApproved = false,
            };

            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                _logger.Log($"Пользователь {user.Email} зарегистрирован. Ожидает подтверждения менеджера.", LogLevel.Info);
            }
            catch (Exception ex)
            {
                _logger.Log($"Ошибка при регистрации пользователя: {ex.Message}", LogLevel.Error);  
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public void ApproveUserRegistration(string userId, BankDbContext context)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                user.IsApproved = true;
                context.SaveChanges();
                _logger.Log($"Регистрация пользователя {user.Email} подтверждена менеджером.", LogLevel.Info);
                Console.WriteLine("Регистрация подтверждена.");
            }
            else
            {
                Console.WriteLine("Пользователь не найден.");
            }
        }

        public User Authenticate(BankDbContext context, string bankId)
        {
            Console.WriteLine("Вход в систему");

            string email;
            do
            {
                Console.Write("Введите email: ");
                email = Console.ReadLine();
                if (!UserValidator.ValidateEmail(email))
                {
                    Console.WriteLine("Некорректный email. Введите в формате example@example.com.");
                }
            } while (!UserValidator.ValidateEmail(email));

            string documentNumber;
            do
            {
                Console.Write("Введите номер документа (9 цифр): ");
                documentNumber = Console.ReadLine();
                if (!UserValidator.ValidateDocumentNumber(documentNumber))
                {
                    Console.WriteLine("Некорректный номер документа. Введите 9 цифр.");
                }
            } while (!UserValidator.ValidateDocumentNumber(documentNumber));

            var user = context.Users
                .FirstOrDefault(u => u.Email == email && u.DocumentNumber == documentNumber && u.BankId == bankId);

            if (user != null)
            {
                _currentUser = user;
                _logger.Log($"Пользователь {user.Email} вошел в систему.", LogLevel.Info);
                Console.WriteLine($"Добро пожаловать, {user.FullName}!");
            }
            else
            {
                _logger.Log($"Неудачная попытка входа для email: {email}.", LogLevel.Warning);
                Console.WriteLine("Пользователь не найден.");
            }

            return user;
        }

        public async Task<User> FindUserByEmailAndDocumentNumber(string email, string documentNumber)
        {
            var users = await _userService.GetAllUsersAsync();
            return users.FirstOrDefault(u => u.Email == email && u.DocumentNumber == documentNumber);
        }

        public void LogoutUser()
        {
            if (_currentUser != null)
            {
                _logger.Log($"Пользователь {_currentUser.Email} вышел из системы.", LogLevel.Info);
                _currentUser = null;
                Console.WriteLine("Вы вышли из системы.");
            }
            else
            {
                Console.WriteLine("Нет активного пользователя для выхода.");
            }
        }


        public void UpdateUserBank(BankDbContext context, string bankId)
        {
            if (_currentUser != null)
            {
                _currentUser.BankId = bankId;
                context.SaveChanges();
                Console.WriteLine($"Банк успешно изменен на {bankId}.");
            }
            else
            {
                Console.WriteLine("Пользователь не авторизован.");
            }
        }
    }
}
