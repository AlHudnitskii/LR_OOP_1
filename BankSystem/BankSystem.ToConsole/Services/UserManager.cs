    using OOP_LR1.BankSystem.Application.Services;
    using OOP_LR1.BankSystem.ToConsole.Style;

    namespace OOP_LR1.BankSystem.ToConsole.Services
    {
        public class UserManager
        {
            private readonly UserService _userService;

            public UserManager(UserService userService)
            {
                _userService = userService;
            }

            public async void ShowAllUsers()
            {
                var users = await _userService.GetAllUsersAsync();

                if (!users.Any())
                {
                    Console.WriteLine("Пользователи не найдены.");
                    return;
                }

                string[] headers = { "ID", "ФИО", "Email", "Телефон", "Роль" };
                var rows = users.Select(u => new[]
                {
                    u.Id,
                    u.FullName,
                    u.Email,
                    u.PhoneNumber,
                    u.Role.ToString()
                }).ToList();

                TableDrawer.DrawTable(headers, rows);
            }
        }
    }
