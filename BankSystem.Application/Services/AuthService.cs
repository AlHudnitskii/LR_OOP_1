using OOP_LR1.BankSystem.Core.Interfaces;
using OOP_LR1.BankSystem.Core.Models;
using OOP_LR1.BankSystem.Infrastructure.Logging;

namespace OOP_LR1.BankSystem.Application.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly Logger _logger;

        public AuthService(IUserRepository userRepository, Logger logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public void Register(User user)
        {
            if (_userRepository.GetAllUsers().Any(u => u.Email == user.Email))
            {
                throw new Exception("Пользователь с таким email уже существует.");
            }

            _userRepository.AddUser(user);
            _logger.Log($"Зарегистрирован новый пользователь: {user.Email}.");
        }
        public User FindUserByEmailAndDocumentNumber(string email, string documentNumber)
        {
            return _userRepository.GetAllUsers()
                .FirstOrDefault(u => u.Email == email && u.DocumentNumber == documentNumber);
        }
    }
}

