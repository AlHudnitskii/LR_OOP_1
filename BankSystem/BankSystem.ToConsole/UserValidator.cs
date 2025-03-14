using System.Text.RegularExpressions;

namespace OOP_LR1.BankSystem.ToConsole
{
    public class UserValidator
    {
        public static bool ValidateFullName(string fullName)
        {
            return !string.IsNullOrWhiteSpace(fullName) && Regex.IsMatch(fullName, @"^[а-яА-ЯёЁa-zA-Z\s]+$");
        }

        public static bool ValidateDocumentNumber(string documentNumber)
        {
            return !string.IsNullOrWhiteSpace(documentNumber) && Regex.IsMatch(documentNumber, @"^\d{9}$");
        }

        public static string SelectDocumentType()
        {
            Console.WriteLine("Выберите тип документа:");
            Console.WriteLine("1. Паспорт");
            Console.WriteLine("2. ID-карта");
            Console.WriteLine("3. Водительское удостоверение");

            while (true)
            {
                Console.Write("Ваш выбор: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        return "Паспорт";
                    case "2":
                        return "ID-карта";
                    case "3":
                        return "Водительское удостоверение";
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, введите число от 1 до 3.");
                        break;
                }
            }
        }

        public static bool ValidateCitizenship(string citizenship)
        {
            return !string.IsNullOrWhiteSpace(citizenship) && Regex.IsMatch(citizenship, @"^[а-яА-ЯёЁa-zA-Z\s]+$");
        }

        public static bool ValidateCountryOfResidence(string country)
        {
            return !string.IsNullOrWhiteSpace(country) && Regex.IsMatch(country, @"^[а-яА-ЯёЁa-zA-Z\s]+$");
        }

        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            var regex = new Regex(@"^\+\d{7,15}$");
            return regex.IsMatch(phoneNumber);
        }
        public static bool ValidateEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
