using OOP_LR1.BankSystem.Application.Services;
using OOP_LR1.BankSystem.Infrastructure.Logging;
using OOP_LR1.BankSystem.Infrastructure.Repositories;
using OOP_LR1.BankSystem.ToConsole.Services;
using System.Text;

namespace OOP_LR1.BankSystem.ToConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            var userRepository = new UserRepository();
            var logger = new Logger("logs.txt");
            var authService = new AuthService(userRepository, logger);
            var userService = new UserService(userRepository);

            var authManager = new AuthManager(authService);
            var userManager = new UserManager(userService);
            var menuManager = new MenuManager(authManager, userManager);

            while (true)
            {
                menuManager.ShowMainMenu(); 
                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();
                menuManager.HandleChoice(choice); 
            }
        }
    }
}
