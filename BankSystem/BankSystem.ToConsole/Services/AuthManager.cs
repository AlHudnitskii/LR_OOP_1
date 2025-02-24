using OOP_LR1.BankSystem.Application.Services;
using OOP_LR1.BankSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LR1.BankSystem.ToConsole.Services
{
    public class AuthManager
    {
        private readonly AuthService _authService;
        private User _currentUser;

        public AuthManager(AuthService authService)
        {
            _authService = authService;
        }

        public User CurrentUser => _currentUser;

        public void RegisterUser()
        {
            Console.WriteLine("Регистрация нового пользователя");

            string fullName;
            do
            {
                Console.Write("Введите ФИО: ");
                fullName = Console.ReadLine();
                if (!UserValidator.ValidateFullName(fullName))
                {
                    Console.WriteLine("Некорректное ФИО. Используйте только буквы и пробелы.");
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

            string documentType;
            do
            {
                Console.Write("Введите тип документа (Паспорт, ID-карта, Водительское удостоверение): ");
                documentType = Console.ReadLine();
                if (!UserValidator.ValidateDocumentType(documentType))
                {
                    Console.WriteLine("Некорректный тип документа. Выберите из списка.");
                }
            } while (!UserValidator.ValidateDocumentType(documentType));

            string citizenship;
            do
            {
                Console.Write("Введите гражданство: ");
                citizenship = Console.ReadLine();
                if (!UserValidator.ValidateCitizenship(citizenship))
                {
                    Console.WriteLine("Некорректное гражданство. Используйте только буквы.");
                }
            } while (!UserValidator.ValidateCitizenship(citizenship));

            string countryOfResidence;
            do
            {
                Console.Write("Введите страну проживания: ");
                countryOfResidence = Console.ReadLine();
                if (!UserValidator.ValidateCountryOfResidence(countryOfResidence))
                {
                    Console.WriteLine("Некорректная страна проживания. Используйте только буквы.");
                }
            } while (!UserValidator.ValidateCountryOfResidence(countryOfResidence));

            string phoneNumber;
            do
            {
                Console.Write("Введите номер телефона (+375XXXXXXXXX): ");
                phoneNumber = Console.ReadLine();
                if (!UserValidator.ValidatePhoneNumber(phoneNumber))
                {
                    Console.WriteLine("Некорректный номер телефона. Введите в формате +375XXXXXXXXX.");
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
            Console.WriteLine("4. Администратор");
            Console.Write("Ваш выбор: ");
            string roleChoice = Console.ReadLine();

            Role role = roleChoice switch
            {
                "1" => Role.Client,
                "2" => Role.Operator,
                "3" => Role.Manager,
                "4" => Role.Administrator,
                _ => Role.Client
            };

            var user = new User
            {
                FullName = fullName,
                DocumentNumber = documentNumber,
                DocumentType = documentType,
                Citizenship = citizenship,
                CountryOfResidence = countryOfResidence,
                PhoneNumber = phoneNumber,
                Email = email,
                Role = role
            };

            try
            {
                _authService.Register(user);
                Console.WriteLine("Регистрация прошла успешно!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
