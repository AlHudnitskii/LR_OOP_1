using OOP_LR1.BankSystem.Application.Services;
using OOP_LR1.BankSystem.Infrastructure;
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

            using var context = new BankDbContext();

            var userRepository = new UserRepository(context);
            var logger = new Logger("logs.txt");
            var authService = new AuthService(userRepository, logger);
            var userService = new UserService(userRepository);

            var authManager = new AuthManager(authService);
            var userManager = new UserManager(userService);
            var menuManager = new MenuManager(authManager, userManager);

            var selectedBank = menuManager.SelectBank(context);
            Console.WriteLine($"Выбран банк: {selectedBank.Name}");

            while (true)
            {
                menuManager.ShowMainMenu();
                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    menuManager.ShowCurrentUser();
                }
                else if (choice == "2")
                {
                    var user = authManager.Authenticate(context, selectedBank.Id);
                    if (user != null)
                    {
                        while (true)
                        {
                            menuManager.ShowRoleMenu(user);
                            Console.Write("Выберите действие: ");
                            string roleChoice = Console.ReadLine();

                            if (roleChoice == "3")
                            {
                                authManager.LogoutUser();
                                break;
                            }

                            menuManager.HandleRoleChoice(roleChoice, user, context);
                        }
                    }
                }
                else if (choice == "3")
                {
                    userManager.ShowAllUsers();
                }
                else if (choice == "4")
                {
                    authManager.LogoutUser();
                }
                else if (choice == "5")
                {
                    menuManager.ShowCurrentUser();
                }
                else if (choice == "6")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                }
            }
        }
    }
}