Проект представляет собой консольное приложение для управления банковской системой. Пользователи могут регистрироваться, входить в систему, управлять счетами, оформлять кредиты и взаимодействовать с зарплатными проектами.

Архитектура:
Слоистая архитектура:
Core: Модели данных и интерфейсы.
Infrastructure: Репозитории и работа с базой данных.
Application: Бизнес-логика.
ToConsole: Пользовательский интерфейс.

Паттерны проектирования:
Repository Pattern: Для абстракции доступа к данным.
Service Layer: Для разделения бизнес-логики.
Dependency Injection: Для внедрения зависимостей.

Основные функции:
Регистрация и авторизация пользователей.
Управление счетами (создание, блокировка, перевод средств).
Оформление и погашение кредитов.
Управление зарплатными проектами.