using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OOP_LR1.Migrations
{
    /// <inheritdoc />
    public partial class alex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    InterestRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    TermInMonths = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsPaid = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    SenderAccountNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ReceiverAccountNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enterprises",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    LegalAddress = table.Column<string>(type: "TEXT", nullable: false),
                    TaxNumber = table.Column<string>(type: "TEXT", nullable: false),
                    BankId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enterprises_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    DocumentNumber = table.Column<string>(type: "TEXT", nullable: false),
                    DocumentType = table.Column<string>(type: "TEXT", nullable: false),
                    Citizenship = table.Column<string>(type: "TEXT", nullable: false),
                    CountryOfResidence = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    BankId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryProjects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    EnterpriseId = table.Column<string>(type: "TEXT", nullable: false),
                    BankId = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryProjects_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaryProjects_Enterprises_EnterpriseId",
                        column: x => x.EnterpriseId,
                        principalTable: "Enterprises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    AccountNumber = table.Column<string>(type: "TEXT", nullable: false),
                    IsBlocked = table.Column<bool>(type: "INTEGER", nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    OwnerId = table.Column<string>(type: "TEXT", nullable: false),
                    BankId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1", "Банк 1" },
                    { "2", "Банк 2" },
                    { "3", "Банк 3" }
                });

            migrationBuilder.InsertData(
                table: "Enterprises",
                columns: new[] { "Id", "BankId", "LegalAddress", "Name", "TaxNumber", "Type" },
                values: new object[,]
                {
                    { "1", "2", "ул. Пушкина 1", "Предприятие 1", "1000000001", "ИП" },
                    { "10", "2", "ул. Пушкина 10", "Предприятие 10", "1000000010", "ООО" },
                    { "2", "3", "ул. Пушкина 2", "Предприятие 2", "1000000002", "ООО" },
                    { "3", "1", "ул. Пушкина 3", "Предприятие 3", "1000000003", "ИП" },
                    { "4", "2", "ул. Пушкина 4", "Предприятие 4", "1000000004", "ООО" },
                    { "5", "3", "ул. Пушкина 5", "Предприятие 5", "1000000005", "ИП" },
                    { "6", "1", "ул. Пушкина 6", "Предприятие 6", "1000000006", "ООО" },
                    { "7", "2", "ул. Пушкина 7", "Предприятие 7", "1000000007", "ИП" },
                    { "8", "3", "ул. Пушкина 8", "Предприятие 8", "1000000008", "ООО" },
                    { "9", "1", "ул. Пушкина 9", "Предприятие 9", "1000000009", "ИП" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BankId", "Citizenship", "CountryOfResidence", "DocumentNumber", "DocumentType", "Email", "FullName", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { "1", "2", "Беларусь", "Беларусь", "1111000001", "Паспорт", "client1@example.com", "Клиент 1", "+375 29 1000020", 0 },
                    { "10", "2", "Россия", "Россия", "1111000010", "Паспорт", "client10@example.com", "Клиент 10", "+375 29 1000200", 0 },
                    { "100", "2", "Россия", "Россия", "1111000100", "Паспорт", "client100@example.com", "Клиент 100", "+375 29 1002000", 0 },
                    { "11", "3", "Беларусь", "Беларусь", "1111000011", "Паспорт", "client11@example.com", "Клиент 11", "+375 29 1000220", 0 },
                    { "12", "1", "Россия", "Россия", "1111000012", "Паспорт", "client12@example.com", "Клиент 12", "+375 29 1000240", 0 },
                    { "13", "2", "Беларусь", "Беларусь", "1111000013", "Паспорт", "client13@example.com", "Клиент 13", "+375 29 1000260", 0 },
                    { "14", "3", "Россия", "Россия", "1111000014", "Паспорт", "client14@example.com", "Клиент 14", "+375 29 1000280", 0 },
                    { "15", "1", "Беларусь", "Беларусь", "1111000015", "Паспорт", "client15@example.com", "Клиент 15", "+375 29 1000300", 0 },
                    { "16", "2", "Россия", "Россия", "1111000016", "Паспорт", "client16@example.com", "Клиент 16", "+375 29 1000320", 0 },
                    { "17", "3", "Беларусь", "Беларусь", "1111000017", "Паспорт", "client17@example.com", "Клиент 17", "+375 29 1000340", 0 },
                    { "18", "1", "Россия", "Россия", "1111000018", "Паспорт", "client18@example.com", "Клиент 18", "+375 29 1000360", 0 },
                    { "19", "2", "Беларусь", "Беларусь", "1111000019", "Паспорт", "client19@example.com", "Клиент 19", "+375 29 1000380", 0 },
                    { "2", "3", "Россия", "Россия", "1111000002", "Паспорт", "client2@example.com", "Клиент 2", "+375 29 1000040", 0 },
                    { "20", "3", "Россия", "Россия", "1111000020", "Паспорт", "client20@example.com", "Клиент 20", "+375 29 1000400", 0 },
                    { "21", "1", "Беларусь", "Беларусь", "1111000021", "Паспорт", "client21@example.com", "Клиент 21", "+375 29 1000420", 0 },
                    { "22", "2", "Россия", "Россия", "1111000022", "Паспорт", "client22@example.com", "Клиент 22", "+375 29 1000440", 0 },
                    { "23", "3", "Беларусь", "Беларусь", "1111000023", "Паспорт", "client23@example.com", "Клиент 23", "+375 29 1000460", 0 },
                    { "24", "1", "Россия", "Россия", "1111000024", "Паспорт", "client24@example.com", "Клиент 24", "+375 29 1000480", 0 },
                    { "25", "2", "Беларусь", "Беларусь", "1111000025", "Паспорт", "client25@example.com", "Клиент 25", "+375 29 1000500", 0 },
                    { "26", "3", "Россия", "Россия", "1111000026", "Паспорт", "client26@example.com", "Клиент 26", "+375 29 1000520", 0 },
                    { "27", "1", "Беларусь", "Беларусь", "1111000027", "Паспорт", "client27@example.com", "Клиент 27", "+375 29 1000540", 0 },
                    { "28", "2", "Россия", "Россия", "1111000028", "Паспорт", "client28@example.com", "Клиент 28", "+375 29 1000560", 0 },
                    { "29", "3", "Беларусь", "Беларусь", "1111000029", "Паспорт", "client29@example.com", "Клиент 29", "+375 29 1000580", 0 },
                    { "3", "1", "Беларусь", "Беларусь", "1111000003", "Паспорт", "client3@example.com", "Клиент 3", "+375 29 1000060", 0 },
                    { "30", "1", "Россия", "Россия", "1111000030", "Паспорт", "client30@example.com", "Клиент 30", "+375 29 1000600", 0 },
                    { "31", "2", "Беларусь", "Беларусь", "1111000031", "Паспорт", "client31@example.com", "Клиент 31", "+375 29 1000620", 0 },
                    { "32", "3", "Россия", "Россия", "1111000032", "Паспорт", "client32@example.com", "Клиент 32", "+375 29 1000640", 0 },
                    { "33", "1", "Беларусь", "Беларусь", "1111000033", "Паспорт", "client33@example.com", "Клиент 33", "+375 29 1000660", 0 },
                    { "34", "2", "Россия", "Россия", "1111000034", "Паспорт", "client34@example.com", "Клиент 34", "+375 29 1000680", 0 },
                    { "35", "3", "Беларусь", "Беларусь", "1111000035", "Паспорт", "client35@example.com", "Клиент 35", "+375 29 1000700", 0 },
                    { "36", "1", "Россия", "Россия", "1111000036", "Паспорт", "client36@example.com", "Клиент 36", "+375 29 1000720", 0 },
                    { "37", "2", "Беларусь", "Беларусь", "1111000037", "Паспорт", "client37@example.com", "Клиент 37", "+375 29 1000740", 0 },
                    { "38", "3", "Россия", "Россия", "1111000038", "Паспорт", "client38@example.com", "Клиент 38", "+375 29 1000760", 0 },
                    { "39", "1", "Беларусь", "Беларусь", "1111000039", "Паспорт", "client39@example.com", "Клиент 39", "+375 29 1000780", 0 },
                    { "4", "2", "Россия", "Россия", "1111000004", "Паспорт", "client4@example.com", "Клиент 4", "+375 29 1000080", 0 },
                    { "40", "2", "Россия", "Россия", "1111000040", "Паспорт", "client40@example.com", "Клиент 40", "+375 29 1000800", 0 },
                    { "41", "3", "Беларусь", "Беларусь", "1111000041", "Паспорт", "client41@example.com", "Клиент 41", "+375 29 1000820", 0 },
                    { "42", "1", "Россия", "Россия", "1111000042", "Паспорт", "client42@example.com", "Клиент 42", "+375 29 1000840", 0 },
                    { "43", "2", "Беларусь", "Беларусь", "1111000043", "Паспорт", "client43@example.com", "Клиент 43", "+375 29 1000860", 0 },
                    { "44", "3", "Россия", "Россия", "1111000044", "Паспорт", "client44@example.com", "Клиент 44", "+375 29 1000880", 0 },
                    { "45", "1", "Беларусь", "Беларусь", "1111000045", "Паспорт", "client45@example.com", "Клиент 45", "+375 29 1000900", 0 },
                    { "46", "2", "Россия", "Россия", "1111000046", "Паспорт", "client46@example.com", "Клиент 46", "+375 29 1000920", 0 },
                    { "47", "3", "Беларусь", "Беларусь", "1111000047", "Паспорт", "client47@example.com", "Клиент 47", "+375 29 1000940", 0 },
                    { "48", "1", "Россия", "Россия", "1111000048", "Паспорт", "client48@example.com", "Клиент 48", "+375 29 1000960", 0 },
                    { "49", "2", "Беларусь", "Беларусь", "1111000049", "Паспорт", "client49@example.com", "Клиент 49", "+375 29 1000980", 0 },
                    { "5", "3", "Беларусь", "Беларусь", "1111000005", "Паспорт", "client5@example.com", "Клиент 5", "+375 29 1000100", 0 },
                    { "50", "3", "Россия", "Россия", "1111000050", "Паспорт", "client50@example.com", "Клиент 50", "+375 29 1001000", 0 },
                    { "51", "1", "Беларусь", "Беларусь", "1111000051", "Паспорт", "client51@example.com", "Клиент 51", "+375 29 1001020", 0 },
                    { "52", "2", "Россия", "Россия", "1111000052", "Паспорт", "client52@example.com", "Клиент 52", "+375 29 1001040", 0 },
                    { "53", "3", "Беларусь", "Беларусь", "1111000053", "Паспорт", "client53@example.com", "Клиент 53", "+375 29 1001060", 0 },
                    { "54", "1", "Россия", "Россия", "1111000054", "Паспорт", "client54@example.com", "Клиент 54", "+375 29 1001080", 0 },
                    { "55", "2", "Беларусь", "Беларусь", "1111000055", "Паспорт", "client55@example.com", "Клиент 55", "+375 29 1001100", 0 },
                    { "56", "3", "Россия", "Россия", "1111000056", "Паспорт", "client56@example.com", "Клиент 56", "+375 29 1001120", 0 },
                    { "57", "1", "Беларусь", "Беларусь", "1111000057", "Паспорт", "client57@example.com", "Клиент 57", "+375 29 1001140", 0 },
                    { "58", "2", "Россия", "Россия", "1111000058", "Паспорт", "client58@example.com", "Клиент 58", "+375 29 1001160", 0 },
                    { "59", "3", "Беларусь", "Беларусь", "1111000059", "Паспорт", "client59@example.com", "Клиент 59", "+375 29 1001180", 0 },
                    { "6", "1", "Россия", "Россия", "1111000006", "Паспорт", "client6@example.com", "Клиент 6", "+375 29 1000120", 0 },
                    { "60", "1", "Россия", "Россия", "1111000060", "Паспорт", "client60@example.com", "Клиент 60", "+375 29 1001200", 0 },
                    { "61", "2", "Беларусь", "Беларусь", "1111000061", "Паспорт", "client61@example.com", "Клиент 61", "+375 29 1001220", 0 },
                    { "62", "3", "Россия", "Россия", "1111000062", "Паспорт", "client62@example.com", "Клиент 62", "+375 29 1001240", 0 },
                    { "63", "1", "Беларусь", "Беларусь", "1111000063", "Паспорт", "client63@example.com", "Клиент 63", "+375 29 1001260", 0 },
                    { "64", "2", "Россия", "Россия", "1111000064", "Паспорт", "client64@example.com", "Клиент 64", "+375 29 1001280", 0 },
                    { "65", "3", "Беларусь", "Беларусь", "1111000065", "Паспорт", "client65@example.com", "Клиент 65", "+375 29 1001300", 0 },
                    { "66", "1", "Россия", "Россия", "1111000066", "Паспорт", "client66@example.com", "Клиент 66", "+375 29 1001320", 0 },
                    { "67", "2", "Беларусь", "Беларусь", "1111000067", "Паспорт", "client67@example.com", "Клиент 67", "+375 29 1001340", 0 },
                    { "68", "3", "Россия", "Россия", "1111000068", "Паспорт", "client68@example.com", "Клиент 68", "+375 29 1001360", 0 },
                    { "69", "1", "Беларусь", "Беларусь", "1111000069", "Паспорт", "client69@example.com", "Клиент 69", "+375 29 1001380", 0 },
                    { "7", "2", "Беларусь", "Беларусь", "1111000007", "Паспорт", "client7@example.com", "Клиент 7", "+375 29 1000140", 0 },
                    { "70", "2", "Россия", "Россия", "1111000070", "Паспорт", "client70@example.com", "Клиент 70", "+375 29 1001400", 0 },
                    { "71", "3", "Беларусь", "Беларусь", "1111000071", "Паспорт", "client71@example.com", "Клиент 71", "+375 29 1001420", 0 },
                    { "72", "1", "Россия", "Россия", "1111000072", "Паспорт", "client72@example.com", "Клиент 72", "+375 29 1001440", 0 },
                    { "73", "2", "Беларусь", "Беларусь", "1111000073", "Паспорт", "client73@example.com", "Клиент 73", "+375 29 1001460", 0 },
                    { "74", "3", "Россия", "Россия", "1111000074", "Паспорт", "client74@example.com", "Клиент 74", "+375 29 1001480", 0 },
                    { "75", "1", "Беларусь", "Беларусь", "1111000075", "Паспорт", "client75@example.com", "Клиент 75", "+375 29 1001500", 0 },
                    { "76", "2", "Россия", "Россия", "1111000076", "Паспорт", "client76@example.com", "Клиент 76", "+375 29 1001520", 0 },
                    { "77", "3", "Беларусь", "Беларусь", "1111000077", "Паспорт", "client77@example.com", "Клиент 77", "+375 29 1001540", 0 },
                    { "78", "1", "Россия", "Россия", "1111000078", "Паспорт", "client78@example.com", "Клиент 78", "+375 29 1001560", 0 },
                    { "79", "2", "Беларусь", "Беларусь", "1111000079", "Паспорт", "client79@example.com", "Клиент 79", "+375 29 1001580", 0 },
                    { "8", "3", "Россия", "Россия", "1111000008", "Паспорт", "client8@example.com", "Клиент 8", "+375 29 1000160", 0 },
                    { "80", "3", "Россия", "Россия", "1111000080", "Паспорт", "client80@example.com", "Клиент 80", "+375 29 1001600", 0 },
                    { "81", "1", "Беларусь", "Беларусь", "1111000081", "Паспорт", "client81@example.com", "Клиент 81", "+375 29 1001620", 0 },
                    { "82", "2", "Россия", "Россия", "1111000082", "Паспорт", "client82@example.com", "Клиент 82", "+375 29 1001640", 0 },
                    { "83", "3", "Беларусь", "Беларусь", "1111000083", "Паспорт", "client83@example.com", "Клиент 83", "+375 29 1001660", 0 },
                    { "84", "1", "Россия", "Россия", "1111000084", "Паспорт", "client84@example.com", "Клиент 84", "+375 29 1001680", 0 },
                    { "85", "2", "Беларусь", "Беларусь", "1111000085", "Паспорт", "client85@example.com", "Клиент 85", "+375 29 1001700", 0 },
                    { "86", "3", "Россия", "Россия", "1111000086", "Паспорт", "client86@example.com", "Клиент 86", "+375 29 1001720", 0 },
                    { "87", "1", "Беларусь", "Беларусь", "1111000087", "Паспорт", "client87@example.com", "Клиент 87", "+375 29 1001740", 0 },
                    { "88", "2", "Россия", "Россия", "1111000088", "Паспорт", "client88@example.com", "Клиент 88", "+375 29 1001760", 0 },
                    { "89", "3", "Беларусь", "Беларусь", "1111000089", "Паспорт", "client89@example.com", "Клиент 89", "+375 29 1001780", 0 },
                    { "9", "1", "Беларусь", "Беларусь", "1111000009", "Паспорт", "client9@example.com", "Клиент 9", "+375 29 1000180", 0 },
                    { "90", "1", "Россия", "Россия", "1111000090", "Паспорт", "client90@example.com", "Клиент 90", "+375 29 1001800", 0 },
                    { "91", "2", "Беларусь", "Беларусь", "1111000091", "Паспорт", "client91@example.com", "Клиент 91", "+375 29 1001820", 0 },
                    { "92", "3", "Россия", "Россия", "1111000092", "Паспорт", "client92@example.com", "Клиент 92", "+375 29 1001840", 0 },
                    { "93", "1", "Беларусь", "Беларусь", "1111000093", "Паспорт", "client93@example.com", "Клиент 93", "+375 29 1001860", 0 },
                    { "94", "2", "Россия", "Россия", "1111000094", "Паспорт", "client94@example.com", "Клиент 94", "+375 29 1001880", 0 },
                    { "95", "3", "Беларусь", "Беларусь", "1111000095", "Паспорт", "client95@example.com", "Клиент 95", "+375 29 1001900", 0 },
                    { "96", "1", "Россия", "Россия", "1111000096", "Паспорт", "client96@example.com", "Клиент 96", "+375 29 1001920", 0 },
                    { "97", "2", "Беларусь", "Беларусь", "1111000097", "Паспорт", "client97@example.com", "Клиент 97", "+375 29 1001940", 0 },
                    { "98", "3", "Россия", "Россия", "1111000098", "Паспорт", "client98@example.com", "Клиент 98", "+375 29 1001960", 0 },
                    { "99", "1", "Беларусь", "Беларусь", "1111000099", "Паспорт", "client99@example.com", "Клиент 99", "+375 29 1001980", 0 }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "Balance", "BankId", "IsBlocked", "OwnerId" },
                values: new object[,]
                {
                    { "1", "ACC1", 1000m, "2", false, "1" },
                    { "10", "ACC10", 1000m, "3", false, "5" },
                    { "100", "ACC100", 1000m, "3", false, "50" },
                    { "101", "ACC101", 1000m, "1", false, "51" },
                    { "102", "ACC102", 1000m, "1", false, "51" },
                    { "103", "ACC103", 1000m, "2", false, "52" },
                    { "104", "ACC104", 1000m, "2", false, "52" },
                    { "105", "ACC105", 1000m, "3", false, "53" },
                    { "106", "ACC106", 1000m, "3", false, "53" },
                    { "107", "ACC107", 1000m, "1", false, "54" },
                    { "108", "ACC108", 1000m, "1", false, "54" },
                    { "109", "ACC109", 1000m, "2", false, "55" },
                    { "11", "ACC11", 1000m, "1", false, "6" },
                    { "110", "ACC110", 1000m, "2", false, "55" },
                    { "111", "ACC111", 1000m, "3", false, "56" },
                    { "112", "ACC112", 1000m, "3", false, "56" },
                    { "113", "ACC113", 1000m, "1", false, "57" },
                    { "114", "ACC114", 1000m, "1", false, "57" },
                    { "115", "ACC115", 1000m, "2", false, "58" },
                    { "116", "ACC116", 1000m, "2", false, "58" },
                    { "117", "ACC117", 1000m, "3", false, "59" },
                    { "118", "ACC118", 1000m, "3", false, "59" },
                    { "119", "ACC119", 1000m, "1", false, "60" },
                    { "12", "ACC12", 1000m, "1", false, "6" },
                    { "120", "ACC120", 1000m, "1", false, "60" },
                    { "121", "ACC121", 1000m, "2", false, "61" },
                    { "122", "ACC122", 1000m, "2", false, "61" },
                    { "123", "ACC123", 1000m, "3", false, "62" },
                    { "124", "ACC124", 1000m, "3", false, "62" },
                    { "125", "ACC125", 1000m, "1", false, "63" },
                    { "126", "ACC126", 1000m, "1", false, "63" },
                    { "127", "ACC127", 1000m, "2", false, "64" },
                    { "128", "ACC128", 1000m, "2", false, "64" },
                    { "129", "ACC129", 1000m, "3", false, "65" },
                    { "13", "ACC13", 1000m, "2", false, "7" },
                    { "130", "ACC130", 1000m, "3", false, "65" },
                    { "131", "ACC131", 1000m, "1", false, "66" },
                    { "132", "ACC132", 1000m, "1", false, "66" },
                    { "133", "ACC133", 1000m, "2", false, "67" },
                    { "134", "ACC134", 1000m, "2", false, "67" },
                    { "135", "ACC135", 1000m, "3", false, "68" },
                    { "136", "ACC136", 1000m, "3", false, "68" },
                    { "137", "ACC137", 1000m, "1", false, "69" },
                    { "138", "ACC138", 1000m, "1", false, "69" },
                    { "139", "ACC139", 1000m, "2", false, "70" },
                    { "14", "ACC14", 1000m, "2", false, "7" },
                    { "140", "ACC140", 1000m, "2", false, "70" },
                    { "141", "ACC141", 1000m, "3", false, "71" },
                    { "142", "ACC142", 1000m, "3", false, "71" },
                    { "143", "ACC143", 1000m, "1", false, "72" },
                    { "144", "ACC144", 1000m, "1", false, "72" },
                    { "145", "ACC145", 1000m, "2", false, "73" },
                    { "146", "ACC146", 1000m, "2", false, "73" },
                    { "147", "ACC147", 1000m, "3", false, "74" },
                    { "148", "ACC148", 1000m, "3", false, "74" },
                    { "149", "ACC149", 1000m, "1", false, "75" },
                    { "15", "ACC15", 1000m, "3", false, "8" },
                    { "150", "ACC150", 1000m, "1", false, "75" },
                    { "151", "ACC151", 1000m, "2", false, "76" },
                    { "152", "ACC152", 1000m, "2", false, "76" },
                    { "153", "ACC153", 1000m, "3", false, "77" },
                    { "154", "ACC154", 1000m, "3", false, "77" },
                    { "155", "ACC155", 1000m, "1", false, "78" },
                    { "156", "ACC156", 1000m, "1", false, "78" },
                    { "157", "ACC157", 1000m, "2", false, "79" },
                    { "158", "ACC158", 1000m, "2", false, "79" },
                    { "159", "ACC159", 1000m, "3", false, "80" },
                    { "16", "ACC16", 1000m, "3", false, "8" },
                    { "160", "ACC160", 1000m, "3", false, "80" },
                    { "161", "ACC161", 1000m, "1", false, "81" },
                    { "162", "ACC162", 1000m, "1", false, "81" },
                    { "163", "ACC163", 1000m, "2", false, "82" },
                    { "164", "ACC164", 1000m, "2", false, "82" },
                    { "165", "ACC165", 1000m, "3", false, "83" },
                    { "166", "ACC166", 1000m, "3", false, "83" },
                    { "167", "ACC167", 1000m, "1", false, "84" },
                    { "168", "ACC168", 1000m, "1", false, "84" },
                    { "169", "ACC169", 1000m, "2", false, "85" },
                    { "17", "ACC17", 1000m, "1", false, "9" },
                    { "170", "ACC170", 1000m, "2", false, "85" },
                    { "171", "ACC171", 1000m, "3", false, "86" },
                    { "172", "ACC172", 1000m, "3", false, "86" },
                    { "173", "ACC173", 1000m, "1", false, "87" },
                    { "174", "ACC174", 1000m, "1", false, "87" },
                    { "175", "ACC175", 1000m, "2", false, "88" },
                    { "176", "ACC176", 1000m, "2", false, "88" },
                    { "177", "ACC177", 1000m, "3", false, "89" },
                    { "178", "ACC178", 1000m, "3", false, "89" },
                    { "179", "ACC179", 1000m, "1", false, "90" },
                    { "18", "ACC18", 1000m, "1", false, "9" },
                    { "180", "ACC180", 1000m, "1", false, "90" },
                    { "181", "ACC181", 1000m, "2", false, "91" },
                    { "182", "ACC182", 1000m, "2", false, "91" },
                    { "183", "ACC183", 1000m, "3", false, "92" },
                    { "184", "ACC184", 1000m, "3", false, "92" },
                    { "185", "ACC185", 1000m, "1", false, "93" },
                    { "186", "ACC186", 1000m, "1", false, "93" },
                    { "187", "ACC187", 1000m, "2", false, "94" },
                    { "188", "ACC188", 1000m, "2", false, "94" },
                    { "189", "ACC189", 1000m, "3", false, "95" },
                    { "19", "ACC19", 1000m, "2", false, "10" },
                    { "190", "ACC190", 1000m, "3", false, "95" },
                    { "191", "ACC191", 1000m, "1", false, "96" },
                    { "192", "ACC192", 1000m, "1", false, "96" },
                    { "193", "ACC193", 1000m, "2", false, "97" },
                    { "194", "ACC194", 1000m, "2", false, "97" },
                    { "195", "ACC195", 1000m, "3", false, "98" },
                    { "196", "ACC196", 1000m, "3", false, "98" },
                    { "197", "ACC197", 1000m, "1", false, "99" },
                    { "198", "ACC198", 1000m, "1", false, "99" },
                    { "199", "ACC199", 1000m, "2", false, "100" },
                    { "2", "ACC2", 1000m, "2", false, "1" },
                    { "20", "ACC20", 1000m, "2", false, "10" },
                    { "200", "ACC200", 1000m, "2", false, "100" },
                    { "201", "ACC201", 5000m, "2", false, "1" },
                    { "202", "ACC202", 5000m, "2", false, "1" },
                    { "203", "ACC203", 5000m, "2", false, "1" },
                    { "204", "ACC204", 5000m, "3", false, "2" },
                    { "205", "ACC205", 5000m, "3", false, "2" },
                    { "206", "ACC206", 5000m, "3", false, "2" },
                    { "207", "ACC207", 5000m, "1", false, "3" },
                    { "208", "ACC208", 5000m, "1", false, "3" },
                    { "209", "ACC209", 5000m, "1", false, "3" },
                    { "21", "ACC21", 1000m, "3", false, "11" },
                    { "210", "ACC210", 5000m, "2", false, "4" },
                    { "211", "ACC211", 5000m, "2", false, "4" },
                    { "212", "ACC212", 5000m, "2", false, "4" },
                    { "213", "ACC213", 5000m, "3", false, "5" },
                    { "214", "ACC214", 5000m, "3", false, "5" },
                    { "215", "ACC215", 5000m, "3", false, "5" },
                    { "216", "ACC216", 5000m, "1", false, "6" },
                    { "217", "ACC217", 5000m, "1", false, "6" },
                    { "218", "ACC218", 5000m, "1", false, "6" },
                    { "219", "ACC219", 5000m, "2", false, "7" },
                    { "22", "ACC22", 1000m, "3", false, "11" },
                    { "220", "ACC220", 5000m, "2", false, "7" },
                    { "221", "ACC221", 5000m, "2", false, "7" },
                    { "222", "ACC222", 5000m, "3", false, "8" },
                    { "223", "ACC223", 5000m, "3", false, "8" },
                    { "224", "ACC224", 5000m, "3", false, "8" },
                    { "225", "ACC225", 5000m, "1", false, "9" },
                    { "226", "ACC226", 5000m, "1", false, "9" },
                    { "227", "ACC227", 5000m, "1", false, "9" },
                    { "228", "ACC228", 5000m, "2", false, "10" },
                    { "229", "ACC229", 5000m, "2", false, "10" },
                    { "23", "ACC23", 1000m, "1", false, "12" },
                    { "230", "ACC230", 5000m, "2", false, "10" },
                    { "24", "ACC24", 1000m, "1", false, "12" },
                    { "25", "ACC25", 1000m, "2", false, "13" },
                    { "26", "ACC26", 1000m, "2", false, "13" },
                    { "27", "ACC27", 1000m, "3", false, "14" },
                    { "28", "ACC28", 1000m, "3", false, "14" },
                    { "29", "ACC29", 1000m, "1", false, "15" },
                    { "3", "ACC3", 1000m, "3", false, "2" },
                    { "30", "ACC30", 1000m, "1", false, "15" },
                    { "31", "ACC31", 1000m, "2", false, "16" },
                    { "32", "ACC32", 1000m, "2", false, "16" },
                    { "33", "ACC33", 1000m, "3", false, "17" },
                    { "34", "ACC34", 1000m, "3", false, "17" },
                    { "35", "ACC35", 1000m, "1", false, "18" },
                    { "36", "ACC36", 1000m, "1", false, "18" },
                    { "37", "ACC37", 1000m, "2", false, "19" },
                    { "38", "ACC38", 1000m, "2", false, "19" },
                    { "39", "ACC39", 1000m, "3", false, "20" },
                    { "4", "ACC4", 1000m, "3", false, "2" },
                    { "40", "ACC40", 1000m, "3", false, "20" },
                    { "41", "ACC41", 1000m, "1", false, "21" },
                    { "42", "ACC42", 1000m, "1", false, "21" },
                    { "43", "ACC43", 1000m, "2", false, "22" },
                    { "44", "ACC44", 1000m, "2", false, "22" },
                    { "45", "ACC45", 1000m, "3", false, "23" },
                    { "46", "ACC46", 1000m, "3", false, "23" },
                    { "47", "ACC47", 1000m, "1", false, "24" },
                    { "48", "ACC48", 1000m, "1", false, "24" },
                    { "49", "ACC49", 1000m, "2", false, "25" },
                    { "5", "ACC5", 1000m, "1", false, "3" },
                    { "50", "ACC50", 1000m, "2", false, "25" },
                    { "51", "ACC51", 1000m, "3", false, "26" },
                    { "52", "ACC52", 1000m, "3", false, "26" },
                    { "53", "ACC53", 1000m, "1", false, "27" },
                    { "54", "ACC54", 1000m, "1", false, "27" },
                    { "55", "ACC55", 1000m, "2", false, "28" },
                    { "56", "ACC56", 1000m, "2", false, "28" },
                    { "57", "ACC57", 1000m, "3", false, "29" },
                    { "58", "ACC58", 1000m, "3", false, "29" },
                    { "59", "ACC59", 1000m, "1", false, "30" },
                    { "6", "ACC6", 1000m, "1", false, "3" },
                    { "60", "ACC60", 1000m, "1", false, "30" },
                    { "61", "ACC61", 1000m, "2", false, "31" },
                    { "62", "ACC62", 1000m, "2", false, "31" },
                    { "63", "ACC63", 1000m, "3", false, "32" },
                    { "64", "ACC64", 1000m, "3", false, "32" },
                    { "65", "ACC65", 1000m, "1", false, "33" },
                    { "66", "ACC66", 1000m, "1", false, "33" },
                    { "67", "ACC67", 1000m, "2", false, "34" },
                    { "68", "ACC68", 1000m, "2", false, "34" },
                    { "69", "ACC69", 1000m, "3", false, "35" },
                    { "7", "ACC7", 1000m, "2", false, "4" },
                    { "70", "ACC70", 1000m, "3", false, "35" },
                    { "71", "ACC71", 1000m, "1", false, "36" },
                    { "72", "ACC72", 1000m, "1", false, "36" },
                    { "73", "ACC73", 1000m, "2", false, "37" },
                    { "74", "ACC74", 1000m, "2", false, "37" },
                    { "75", "ACC75", 1000m, "3", false, "38" },
                    { "76", "ACC76", 1000m, "3", false, "38" },
                    { "77", "ACC77", 1000m, "1", false, "39" },
                    { "78", "ACC78", 1000m, "1", false, "39" },
                    { "79", "ACC79", 1000m, "2", false, "40" },
                    { "8", "ACC8", 1000m, "2", false, "4" },
                    { "80", "ACC80", 1000m, "2", false, "40" },
                    { "81", "ACC81", 1000m, "3", false, "41" },
                    { "82", "ACC82", 1000m, "3", false, "41" },
                    { "83", "ACC83", 1000m, "1", false, "42" },
                    { "84", "ACC84", 1000m, "1", false, "42" },
                    { "85", "ACC85", 1000m, "2", false, "43" },
                    { "86", "ACC86", 1000m, "2", false, "43" },
                    { "87", "ACC87", 1000m, "3", false, "44" },
                    { "88", "ACC88", 1000m, "3", false, "44" },
                    { "89", "ACC89", 1000m, "1", false, "45" },
                    { "9", "ACC9", 1000m, "3", false, "5" },
                    { "90", "ACC90", 1000m, "1", false, "45" },
                    { "91", "ACC91", 1000m, "2", false, "46" },
                    { "92", "ACC92", 1000m, "2", false, "46" },
                    { "93", "ACC93", 1000m, "3", false, "47" },
                    { "94", "ACC94", 1000m, "3", false, "47" },
                    { "95", "ACC95", 1000m, "1", false, "48" },
                    { "96", "ACC96", 1000m, "1", false, "48" },
                    { "97", "ACC97", 1000m, "2", false, "49" },
                    { "98", "ACC98", 1000m, "2", false, "49" },
                    { "99", "ACC99", 1000m, "3", false, "50" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BankId",
                table: "Accounts",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_OwnerId",
                table: "Accounts",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_BankId",
                table: "Enterprises",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryProjects_BankId",
                table: "SalaryProjects",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryProjects_EnterpriseId",
                table: "SalaryProjects",
                column: "EnterpriseId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BankId",
                table: "Users",
                column: "BankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "SalaryProjects");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Enterprises");

            migrationBuilder.DropTable(
                name: "Banks");
        }
    }
}
