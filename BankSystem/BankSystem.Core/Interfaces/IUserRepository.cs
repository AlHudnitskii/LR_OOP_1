using OOP_LR1.BankSystem.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OOP_LR1.BankSystem.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(string id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(string id);
    }
}