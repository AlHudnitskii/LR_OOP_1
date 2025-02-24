using OOP_LR1.BankSystem.Core.Models;

namespace OOP_LR1.BankSystem.Core.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUserById(string userId);
        List<User> GetAllUsers();


    }
}
