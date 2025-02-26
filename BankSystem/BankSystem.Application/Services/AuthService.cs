using OOP_LR1.BankSystem.Core.Interfaces;
using OOP_LR1.BankSystem.Core.Models;
using OOP_LR1.BankSystem.Infrastructure.Logging;
using System.Threading.Tasks;

namespace OOP_LR1.BankSystem.Application.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;

        public AuthService(IUserRepository userRepository, ILogger logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task Register(User user)
        {
            await _userRepository.AddUserAsync(user);
            _logger.Log($"Пользователь {user.Email} зарегистрирован.");
        }

        public async Task<User> FindUserByEmailAndDocumentNumber(string email, string documentNumber)
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.FirstOrDefault(u => u.Email == email && u.DocumentNumber == documentNumber);
        }
    }
}