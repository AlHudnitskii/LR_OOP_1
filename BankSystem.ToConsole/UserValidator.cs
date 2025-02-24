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

        public static bool ValidateDocumentType(string documentType)
        {
            var validTypes = new[] { "Паспорт", "ID-карта", "Водительское удостоверение" };
            return validTypes.Contains(documentType);
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
            return !string.IsNullOrWhiteSpace(phoneNumber) && Regex.IsMatch(phoneNumber, @"^\+$");
        }

        public static bool ValidateEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
