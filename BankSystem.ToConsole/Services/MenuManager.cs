using OOP_LR1.BankSystem.ToConsole.Style;

namespace OOP_LR1.BankSystem.ToConsole.Services
{
    public class MenuManager
    {
        private readonly AuthManager _authManager;
        private readonly UserManager _userManager;

        public MenuManager(AuthManager authManager, UserManager userManager)
        {
            _authManager = authManager;
            _userManager = userManager;
        }

        public void ShowMainMenu()
        {
            string[] headers = { "Номер", "Действие" };
            var rows = new List<string[]>
            {
                new[] { "1", "Регистрация" },
                new[] { "2", "Вход" },
                new[] { "3", "Показать всех пользователей" },
                new[] { "4", "Выход" },
                new[] { "5", "Показать текущего пользователя" },
                new[] { "6", "Выйти из программы" }
            };

            TableDrawer.DrawTable(headers, rows);
        }

        public void HandleChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    _authManager.RegisterUser();
                    break;
                case "2":
                    _authManager.LoginUser();
                    ShowCurrentUser();
                    break;
                case "3":
                    _userManager.ShowAllUsers();
                    break;
                case "4":
                    _authManager.LogoutUser();
                    ShowCurrentUser();
                    break;
                case "5":
                    ShowCurrentUser();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }

        private void ShowCurrentUser()
        {
            var currentUser = _authManager.CurrentUser;
            if (currentUser != null)
            {
                Console.WriteLine($"Текущий пользователь: {currentUser.FullName} ({currentUser.Role})");
            }
            else
            {
                Console.WriteLine("Вы не вошли в систему.");
            }
        }
    }
}
