using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OOP_LR1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    { "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Банк 1" },
                    { "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Банк 2" },
                    { "8999674d-e4b9-412d-8030-24abd3e97b68", "Банк 3" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "Balance", "BankId", "IsBlocked", "OwnerId" },
                values: new object[,]
                {
                    { "0100d249-90bc-4aef-93bc-f92d9bd01862", "4000000209", 827617m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "2424c76b-c26c-48d5-bf15-e9a1b5393aba" },
                    { "06b7e9aa-4945-4c27-8565-5f76f9146718", "4000000202", 258626m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "de9e7354-c770-4402-9321-584993b7dcde" },
                    { "094db239-7e48-4a0b-b9e2-14e0799c887b", "4000000206", 77457m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "d59eb21b-4503-4850-b516-7190e9913714" },
                    { "13c1ec0b-fb63-4999-b351-2c88c1dd1eb2", "4000000216", 605682m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "bafd3cdb-04ad-4d5c-9bd3-384bd2e93e77" },
                    { "140bec33-bad2-4e01-95da-500ca4f53f45", "4000000225", 188409m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "0b1411a2-7303-425d-b8f3-6b0111cc87cc" },
                    { "372df92f-80af-4968-8bc1-c3657fe222e4", "4000000220", 62648m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "32d6d7d3-2054-47f0-b101-ed4fe2ce01f5" },
                    { "38b8dcc1-a932-4b3e-9e22-d0b16cc1cc62", "4000000230", 529465m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "b597b7dc-f4ac-46a7-9487-ea46f123b65d" },
                    { "3acea12b-6ef9-475c-b06a-2cfdc209c7ca", "4000000207", 869783m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "2424c76b-c26c-48d5-bf15-e9a1b5393aba" },
                    { "3eda806d-80a5-4c50-a42a-a069b11aff81", "4000000208", 313365m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "2424c76b-c26c-48d5-bf15-e9a1b5393aba" },
                    { "4a6db6de-7ed2-4f31-8948-879abc071f1c", "4000000227", 303900m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "0b1411a2-7303-425d-b8f3-6b0111cc87cc" },
                    { "51f27864-5e29-4132-b900-08c1a938c10b", "4000000204", 806340m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "d59eb21b-4503-4850-b516-7190e9913714" },
                    { "654bbdc6-a3b0-4c8f-bae0-dc42e221494b", "4000000214", 124203m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "9f888eef-f926-4e4e-9878-7528cb166f15" },
                    { "66e32f54-efaa-4c36-bc85-caf28de7d3ca", "4000000218", 909422m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "bafd3cdb-04ad-4d5c-9bd3-384bd2e93e77" },
                    { "6ad507ee-6d07-4740-bc8d-c8152a5ca160", "4000000215", 93081m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "9f888eef-f926-4e4e-9878-7528cb166f15" },
                    { "6e82e284-eca2-4fcf-8e1a-a9f68564a47b", "4000000203", 152904m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "de9e7354-c770-4402-9321-584993b7dcde" },
                    { "776302ff-7852-481c-81a3-bb545b636dd8", "4000000229", 354283m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "b597b7dc-f4ac-46a7-9487-ea46f123b65d" },
                    { "7f54c16d-b66b-400d-bea6-dd0c76906e38", "4000000210", 239571m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "19329939-0e48-43ba-b911-127649dd8d8c" },
                    { "98860341-6e89-4c3e-a5f9-ac674b9225c4", "4000000213", 587709m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "9f888eef-f926-4e4e-9878-7528cb166f15" },
                    { "a0597377-8dfc-458b-a1a6-4db0de2e3ce4", "4000000224", 50050m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "73ee5ed5-303d-43c6-aa05-0c5d93332d74" },
                    { "a12b41bd-f9af-432d-8876-a3eb6ab116ec", "4000000217", 972983m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "bafd3cdb-04ad-4d5c-9bd3-384bd2e93e77" },
                    { "a8517425-ba9f-4975-a2bd-1f7a7f72f3b1", "4000000226", 829359m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "0b1411a2-7303-425d-b8f3-6b0111cc87cc" },
                    { "aabbfc7b-2ea1-4b86-9e26-4825bc2d23a5", "4000000223", 297353m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "73ee5ed5-303d-43c6-aa05-0c5d93332d74" },
                    { "ac0a438c-41dc-43f2-8847-b4c57442979c", "4000000222", 328893m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "73ee5ed5-303d-43c6-aa05-0c5d93332d74" },
                    { "aea3198b-77e8-4ffa-8c65-b6f9915fe44e", "4000000219", 165589m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "32d6d7d3-2054-47f0-b101-ed4fe2ce01f5" },
                    { "b5ae0e36-c19a-42bc-88db-1e8fcf969b1f", "4000000228", 238998m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "b597b7dc-f4ac-46a7-9487-ea46f123b65d" },
                    { "b78bb6c9-8257-4a3f-b46e-754e6c2b68a6", "4000000201", 927507m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "de9e7354-c770-4402-9321-584993b7dcde" },
                    { "bab554a8-19e6-452d-98bf-c6c92b2f852d", "4000000205", 658320m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "d59eb21b-4503-4850-b516-7190e9913714" },
                    { "c1049f64-5bc4-401a-b30b-b1f4e72c7e70", "4000000212", 628562m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "19329939-0e48-43ba-b911-127649dd8d8c" },
                    { "c926845a-ee48-4ba0-ba46-02f21f06076c", "4000000221", 52790m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "32d6d7d3-2054-47f0-b101-ed4fe2ce01f5" },
                    { "f24414b1-7c12-4989-9acc-e34fe0cb4ee0", "4000000211", 270548m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "19329939-0e48-43ba-b911-127649dd8d8c" }
                });

            migrationBuilder.InsertData(
                table: "Enterprises",
                columns: new[] { "Id", "BankId", "LegalAddress", "Name", "TaxNumber", "Type" },
                values: new object[,]
                {
                    { "0b1411a2-7303-425d-b8f3-6b0111cc87cc", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "ул. Пушкина 9", "Предприятие 9", "1000000009", "ИП" },
                    { "19329939-0e48-43ba-b911-127649dd8d8c", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "ул. Пушкина 4", "Предприятие 4", "1000000004", "ООО" },
                    { "2424c76b-c26c-48d5-bf15-e9a1b5393aba", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "ул. Пушкина 3", "Предприятие 3", "1000000003", "ИП" },
                    { "32d6d7d3-2054-47f0-b101-ed4fe2ce01f5", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "ул. Пушкина 7", "Предприятие 7", "1000000007", "ИП" },
                    { "73ee5ed5-303d-43c6-aa05-0c5d93332d74", "8999674d-e4b9-412d-8030-24abd3e97b68", "ул. Пушкина 8", "Предприятие 8", "1000000008", "ООО" },
                    { "9f888eef-f926-4e4e-9878-7528cb166f15", "8999674d-e4b9-412d-8030-24abd3e97b68", "ул. Пушкина 5", "Предприятие 5", "1000000005", "ИП" },
                    { "b597b7dc-f4ac-46a7-9487-ea46f123b65d", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "ул. Пушкина 10", "Предприятие 10", "1000000010", "ООО" },
                    { "bafd3cdb-04ad-4d5c-9bd3-384bd2e93e77", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "ул. Пушкина 6", "Предприятие 6", "1000000006", "ООО" },
                    { "d59eb21b-4503-4850-b516-7190e9913714", "8999674d-e4b9-412d-8030-24abd3e97b68", "ул. Пушкина 2", "Предприятие 2", "1000000002", "ООО" },
                    { "de9e7354-c770-4402-9321-584993b7dcde", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "ул. Пушкина 1", "Предприятие 1", "1000000001", "ИП" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BankId", "Citizenship", "CountryOfResidence", "DocumentNumber", "DocumentType", "Email", "FullName", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { "0082d1aa-a439-4ed7-8c38-baeba06c6c81", "8999674d-e4b9-412d-8030-24abd3e97b68", "Россия", "Россия", "2000000098", "Паспорт", "client98@example.com", "Клиент 98", "+7 900 1000098", 0 },
                    { "01e93c6a-3d64-4a49-a477-609630a2e0c1", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Беларусь", "Беларусь", "2000000031", "Паспорт", "client31@example.com", "Клиент 31", "+7 900 1000031", 0 },
                    { "023d0b08-d772-4675-a08f-954034564cf5", "8999674d-e4b9-412d-8030-24abd3e97b68", "Беларусь", "Беларусь", "2000000095", "Паспорт", "client95@example.com", "Клиент 95", "+7 900 1000095", 0 },
                    { "0540ce4e-5d02-499e-97dd-2c5b6283179b", "8999674d-e4b9-412d-8030-24abd3e97b68", "Беларусь", "Беларусь", "2000000011", "Паспорт", "client11@example.com", "Клиент 11", "+7 900 1000011", 0 },
                    { "056e91f1-f205-45ae-8178-359729f37564", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Россия", "Россия", "2000000028", "Паспорт", "client28@example.com", "Клиент 28", "+7 900 1000028", 0 },
                    { "08094b0d-d030-4162-9abc-1f030eca614d", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Россия", "Россия", "2000000006", "Паспорт", "client6@example.com", "Клиент 6", "+7 900 1000006", 0 },
                    { "08e21d69-c725-42b4-a68b-043728e9148e", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Беларусь", "Беларусь", "2000000033", "Паспорт", "client33@example.com", "Клиент 33", "+7 900 1000033", 0 },
                    { "0c9daf27-240e-489e-a7af-ea4de0037b90", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Россия", "Россия", "2000000042", "Паспорт", "client42@example.com", "Клиент 42", "+7 900 1000042", 0 },
                    { "0d86112c-2b25-499e-b106-b7db121be61c", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Беларусь", "Беларусь", "2000000075", "Паспорт", "client75@example.com", "Клиент 75", "+7 900 1000075", 0 },
                    { "0dac40b7-60a1-4f4a-8c66-2378f748b5ed", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Россия", "Россия", "2000000072", "Паспорт", "client72@example.com", "Клиент 72", "+7 900 1000072", 0 },
                    { "10883b64-b0c3-46c0-959a-c141a2859cb7", "8999674d-e4b9-412d-8030-24abd3e97b68", "Беларусь", "Беларусь", "2000000047", "Паспорт", "client47@example.com", "Клиент 47", "+7 900 1000047", 0 },
                    { "1799c012-c548-44fc-baac-43482c2835ae", "8999674d-e4b9-412d-8030-24abd3e97b68", "Россия", "Россия", "2000000014", "Паспорт", "client14@example.com", "Клиент 14", "+7 900 1000014", 0 },
                    { "18825c4b-f141-48ef-a2fd-f28cb3144011", "8999674d-e4b9-412d-8030-24abd3e97b68", "Беларусь", "Беларусь", "2000000065", "Паспорт", "client65@example.com", "Клиент 65", "+7 900 1000065", 0 },
                    { "18c1a89e-2542-4fcd-8c0a-9276fe632726", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Беларусь", "Беларусь", "2000000091", "Паспорт", "client91@example.com", "Клиент 91", "+7 900 1000091", 0 },
                    { "2139fc35-0078-4320-9581-78a29a872a39", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Россия", "Россия", "2000000100", "Паспорт", "client100@example.com", "Клиент 100", "+7 900 1000100", 0 },
                    { "215a46bf-1578-4528-9638-df189437ee5e", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Беларусь", "Беларусь", "2000000081", "Паспорт", "client81@example.com", "Клиент 81", "+7 900 1000081", 0 },
                    { "225d8d7b-292f-4068-9b56-d7956fab6f14", "8999674d-e4b9-412d-8030-24abd3e97b68", "Россия", "Россия", "2000000062", "Паспорт", "client62@example.com", "Клиент 62", "+7 900 1000062", 0 },
                    { "2351af36-55ff-4d94-a477-6fc00f6e5457", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Беларусь", "Беларусь", "2000000043", "Паспорт", "client43@example.com", "Клиент 43", "+7 900 1000043", 0 },
                    { "2745294f-d849-4f70-a545-4f76955d1aa5", "8999674d-e4b9-412d-8030-24abd3e97b68", "Беларусь", "Беларусь", "2000000089", "Паспорт", "client89@example.com", "Клиент 89", "+7 900 1000089", 0 },
                    { "27a0997f-a4f9-4dac-8337-7e3d4e97eeb1", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Беларусь", "Беларусь", "2000000049", "Паспорт", "client49@example.com", "Клиент 49", "+7 900 1000049", 0 },
                    { "286f5579-4e1a-42e1-9344-62205054c024", "8999674d-e4b9-412d-8030-24abd3e97b68", "Россия", "Россия", "2000000020", "Паспорт", "client20@example.com", "Клиент 20", "+7 900 1000020", 0 },
                    { "2a9b9a4d-e732-4f27-a4c3-9add97e8933a", "8999674d-e4b9-412d-8030-24abd3e97b68", "Россия", "Россия", "2000000056", "Паспорт", "client56@example.com", "Клиент 56", "+7 900 1000056", 0 },
                    { "3292cd57-5f4d-4ccc-87d4-1577ea3b31af", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Беларусь", "Беларусь", "2000000019", "Паспорт", "client19@example.com", "Клиент 19", "+7 900 1000019", 0 },
                    { "35f2e909-e077-444a-9d0f-29da02e2e3aa", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Беларусь", "Беларусь", "2000000003", "Паспорт", "client3@example.com", "Клиент 3", "+7 900 1000003", 0 },
                    { "36bce292-c863-4dbc-aef3-5ca0c85b8440", "8999674d-e4b9-412d-8030-24abd3e97b68", "Россия", "Россия", "2000000026", "Паспорт", "client26@example.com", "Клиент 26", "+7 900 1000026", 0 },
                    { "392d93a0-a16e-44d1-b783-05fdac6eec4c", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Россия", "Россия", "2000000010", "Паспорт", "client10@example.com", "Клиент 10", "+7 900 1000010", 0 },
                    { "3cdabfd5-445e-40b9-9f5a-38087f3d4e34", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Беларусь", "Беларусь", "2000000085", "Паспорт", "client85@example.com", "Клиент 85", "+7 900 1000085", 0 },
                    { "3d4d309f-5493-4d9e-969d-fa5ad03c8690", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Беларусь", "Беларусь", "2000000061", "Паспорт", "client61@example.com", "Клиент 61", "+7 900 1000061", 0 },
                    { "40af1c11-0666-40ce-96b8-e22fd427eea6", "8999674d-e4b9-412d-8030-24abd3e97b68", "Беларусь", "Беларусь", "2000000035", "Паспорт", "client35@example.com", "Клиент 35", "+7 900 1000035", 0 },
                    { "43895ee0-6d0f-43cc-93f4-1602782858f1", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Беларусь", "Беларусь", "2000000067", "Паспорт", "client67@example.com", "Клиент 67", "+7 900 1000067", 0 },
                    { "4493f76c-55b2-4664-a694-752ae2b2e2fc", "8999674d-e4b9-412d-8030-24abd3e97b68", "Беларусь", "Беларусь", "2000000023", "Паспорт", "client23@example.com", "Клиент 23", "+7 900 1000023", 0 },
                    { "47259eb4-f721-4c9c-a400-a4daa026a1ae", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Беларусь", "Беларусь", "2000000001", "Паспорт", "client1@example.com", "Клиент 1", "+7 900 1000001", 0 },
                    { "4af5e545-757f-4d20-98f6-9cfd33032fa7", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Беларусь", "Беларусь", "2000000037", "Паспорт", "client37@example.com", "Клиент 37", "+7 900 1000037", 0 },
                    { "4b099cca-847e-48a8-9308-bce74338bb90", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Россия", "Россия", "2000000040", "Паспорт", "client40@example.com", "Клиент 40", "+7 900 1000040", 0 },
                    { "50389981-fd4c-420a-98df-669ae66c3e66", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Россия", "Россия", "2000000096", "Паспорт", "client96@example.com", "Клиент 96", "+7 900 1000096", 0 },
                    { "5431e1f9-d8db-4a9d-af87-18c9b19a2b20", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Россия", "Россия", "2000000018", "Паспорт", "client18@example.com", "Клиент 18", "+7 900 1000018", 0 },
                    { "5693d9c4-9485-4aaa-b6fc-6a5ab861af40", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Россия", "Россия", "2000000048", "Паспорт", "client48@example.com", "Клиент 48", "+7 900 1000048", 0 },
                    { "57217908-5b64-45bc-aae3-b81141b03edf", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Россия", "Россия", "2000000088", "Паспорт", "client88@example.com", "Клиент 88", "+7 900 1000088", 0 },
                    { "5796b0a5-116b-4bcd-be1b-962e9cdfda7c", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Беларусь", "Беларусь", "2000000073", "Паспорт", "client73@example.com", "Клиент 73", "+7 900 1000073", 0 },
                    { "59c88718-9d20-4498-9765-33b3a7a843ff", "8999674d-e4b9-412d-8030-24abd3e97b68", "Беларусь", "Беларусь", "2000000077", "Паспорт", "client77@example.com", "Клиент 77", "+7 900 1000077", 0 },
                    { "5f11cad2-b6b2-4054-ac12-a806676daae8", "8999674d-e4b9-412d-8030-24abd3e97b68", "Россия", "Россия", "2000000008", "Паспорт", "client8@example.com", "Клиент 8", "+7 900 1000008", 0 },
                    { "61b26fa9-bc00-4917-b61e-566fc706c2b5", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Россия", "Россия", "2000000046", "Паспорт", "client46@example.com", "Клиент 46", "+7 900 1000046", 0 },
                    { "67cb388b-cc4e-4e95-bbd9-33474b7088ca", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Россия", "Россия", "2000000036", "Паспорт", "client36@example.com", "Клиент 36", "+7 900 1000036", 0 },
                    { "73223ae1-46c4-4d19-a61e-0dfb49774955", "8999674d-e4b9-412d-8030-24abd3e97b68", "Беларусь", "Беларусь", "2000000071", "Паспорт", "client71@example.com", "Клиент 71", "+7 900 1000071", 0 },
                    { "76d5fa37-36e7-46c4-9b54-5925273eb659", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Россия", "Россия", "2000000060", "Паспорт", "client60@example.com", "Клиент 60", "+7 900 1000060", 0 },
                    { "7932d989-611a-48a6-9ed3-68b83f4653ab", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Беларусь", "Беларусь", "2000000051", "Паспорт", "client51@example.com", "Клиент 51", "+7 900 1000051", 0 },
                    { "796ff407-7b51-4866-ba2a-431c6ad6b1bf", "8999674d-e4b9-412d-8030-24abd3e97b68", "Беларусь", "Беларусь", "2000000059", "Паспорт", "client59@example.com", "Клиент 59", "+7 900 1000059", 0 },
                    { "7a4c6e37-cdc3-49c7-85b1-f12c9fd4ba53", "8999674d-e4b9-412d-8030-24abd3e97b68", "Беларусь", "Беларусь", "2000000005", "Паспорт", "client5@example.com", "Клиент 5", "+7 900 1000005", 0 },
                    { "7f2a8d5b-dd9e-49f1-bb1f-77ad1ed48ede", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Россия", "Россия", "2000000082", "Паспорт", "client82@example.com", "Клиент 82", "+7 900 1000082", 0 },
                    { "8127e86b-a015-49e6-b67f-095fc3c7f58d", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Беларусь", "Беларусь", "2000000069", "Паспорт", "client69@example.com", "Клиент 69", "+7 900 1000069", 0 },
                    { "84b43a14-4060-4672-ac1d-2bade002c71c", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Беларусь", "Беларусь", "2000000007", "Паспорт", "client7@example.com", "Клиент 7", "+7 900 1000007", 0 },
                    { "895a2040-ece5-4f6b-8a7f-ca484827abc1", "8999674d-e4b9-412d-8030-24abd3e97b68", "Россия", "Россия", "2000000074", "Паспорт", "client74@example.com", "Клиент 74", "+7 900 1000074", 0 },
                    { "8c674177-23f4-4151-9605-b73645c8afcf", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Беларусь", "Беларусь", "2000000021", "Паспорт", "client21@example.com", "Клиент 21", "+7 900 1000021", 0 },
                    { "9132f2f1-cb92-4482-aae8-f0bb6daf3cec", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Россия", "Россия", "2000000022", "Паспорт", "client22@example.com", "Клиент 22", "+7 900 1000022", 0 },
                    { "935bd585-f9f4-4ac4-a77b-7af0c1c55f16", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Россия", "Россия", "2000000076", "Паспорт", "client76@example.com", "Клиент 76", "+7 900 1000076", 0 },
                    { "93968440-2899-4d17-bd12-aa9cd79b2dbb", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Беларусь", "Беларусь", "2000000057", "Паспорт", "client57@example.com", "Клиент 57", "+7 900 1000057", 0 },
                    { "982efc99-db62-423a-9c90-3b15a1e1514e", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Россия", "Россия", "2000000016", "Паспорт", "client16@example.com", "Клиент 16", "+7 900 1000016", 0 },
                    { "9d146c19-4708-4cca-8725-59acb79de945", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Беларусь", "Беларусь", "2000000063", "Паспорт", "client63@example.com", "Клиент 63", "+7 900 1000063", 0 },
                    { "9eaaf08f-a1be-4d7f-987b-5861a321ad6f", "8999674d-e4b9-412d-8030-24abd3e97b68", "Беларусь", "Беларусь", "2000000017", "Паспорт", "client17@example.com", "Клиент 17", "+7 900 1000017", 0 },
                    { "9ee081d2-3f1c-4185-af72-0686a573648b", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Россия", "Россия", "2000000058", "Паспорт", "client58@example.com", "Клиент 58", "+7 900 1000058", 0 },
                    { "a3b40672-37ee-44b3-8d9d-cd57de6d7dfe", "8999674d-e4b9-412d-8030-24abd3e97b68", "Беларусь", "Беларусь", "2000000029", "Паспорт", "client29@example.com", "Клиент 29", "+7 900 1000029", 0 },
                    { "a4544368-0906-4924-a171-72612f4ff877", "8999674d-e4b9-412d-8030-24abd3e97b68", "Россия", "Россия", "2000000080", "Паспорт", "client80@example.com", "Клиент 80", "+7 900 1000080", 0 },
                    { "a5f5b695-3231-4c0b-aa08-1f483e6cec70", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Россия", "Россия", "2000000078", "Паспорт", "client78@example.com", "Клиент 78", "+7 900 1000078", 0 },
                    { "a8b588b0-3473-4663-ae44-e10fe046ed2c", "8999674d-e4b9-412d-8030-24abd3e97b68", "Россия", "Россия", "2000000068", "Паспорт", "client68@example.com", "Клиент 68", "+7 900 1000068", 0 },
                    { "a8e8c1ee-2a71-4ef7-84cc-009293302f3b", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Беларусь", "Беларусь", "2000000039", "Паспорт", "client39@example.com", "Клиент 39", "+7 900 1000039", 0 },
                    { "a923c3ba-7b4e-4490-a549-bc523dd1ca6f", "8999674d-e4b9-412d-8030-24abd3e97b68", "Россия", "Россия", "2000000092", "Паспорт", "client92@example.com", "Клиент 92", "+7 900 1000092", 0 },
                    { "abb68796-3538-46e2-8a15-a15a9102a25e", "8999674d-e4b9-412d-8030-24abd3e97b68", "Беларусь", "Беларусь", "2000000053", "Паспорт", "client53@example.com", "Клиент 53", "+7 900 1000053", 0 },
                    { "acd659b9-cfd5-42c4-8e0b-b7b60d4ffa5a", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Беларусь", "Беларусь", "2000000027", "Паспорт", "client27@example.com", "Клиент 27", "+7 900 1000027", 0 },
                    { "af9fe7f9-c8a6-4c3c-b909-27c008a2b4e6", "8999674d-e4b9-412d-8030-24abd3e97b68", "Россия", "Россия", "2000000002", "Паспорт", "client2@example.com", "Клиент 2", "+7 900 1000002", 0 },
                    { "b0b14a84-9815-4545-87ad-b3fde41e36c5", "8999674d-e4b9-412d-8030-24abd3e97b68", "Россия", "Россия", "2000000032", "Паспорт", "client32@example.com", "Клиент 32", "+7 900 1000032", 0 },
                    { "b25d01ec-9ada-46e0-8a18-8909f6343e28", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Россия", "Россия", "2000000034", "Паспорт", "client34@example.com", "Клиент 34", "+7 900 1000034", 0 },
                    { "b5c1ff10-0a93-4b22-b56d-0fb614f6c84e", "8999674d-e4b9-412d-8030-24abd3e97b68", "Россия", "Россия", "2000000086", "Паспорт", "client86@example.com", "Клиент 86", "+7 900 1000086", 0 },
                    { "baf7d35a-24da-4be1-9126-39bd867385c9", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Беларусь", "Беларусь", "2000000055", "Паспорт", "client55@example.com", "Клиент 55", "+7 900 1000055", 0 },
                    { "c490632d-1903-422d-9ddf-dc058f19f9e9", "8999674d-e4b9-412d-8030-24abd3e97b68", "Россия", "Россия", "2000000044", "Паспорт", "client44@example.com", "Клиент 44", "+7 900 1000044", 0 },
                    { "c62b247e-89ec-408d-82f5-b102f59b60ef", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Россия", "Россия", "2000000070", "Паспорт", "client70@example.com", "Клиент 70", "+7 900 1000070", 0 },
                    { "c6efbf02-b733-4ea6-aaed-215afa5d7027", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Россия", "Россия", "2000000064", "Паспорт", "client64@example.com", "Клиент 64", "+7 900 1000064", 0 },
                    { "c8f0c5a4-3c04-4ea6-85bf-a0627a694916", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Россия", "Россия", "2000000084", "Паспорт", "client84@example.com", "Клиент 84", "+7 900 1000084", 0 },
                    { "cc3a157f-dd8e-446d-a3fc-ea3d2c44591a", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Беларусь", "Беларусь", "2000000045", "Паспорт", "client45@example.com", "Клиент 45", "+7 900 1000045", 0 },
                    { "ce0f68c7-8d8e-45f1-a054-5f9c97c4cf64", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Беларусь", "Беларусь", "2000000025", "Паспорт", "client25@example.com", "Клиент 25", "+7 900 1000025", 0 },
                    { "ce835b47-17e4-402a-9206-f8f5f1549bb4", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Россия", "Россия", "2000000094", "Паспорт", "client94@example.com", "Клиент 94", "+7 900 1000094", 0 },
                    { "d2296f9c-3334-4248-8d51-f95e59785d61", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Беларусь", "Беларусь", "2000000099", "Паспорт", "client99@example.com", "Клиент 99", "+7 900 1000099", 0 },
                    { "d32f8dab-6e79-4e02-897f-4ecbaca02fa9", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Россия", "Россия", "2000000066", "Паспорт", "client66@example.com", "Клиент 66", "+7 900 1000066", 0 },
                    { "d4457e8b-9067-43bb-b9c2-620621bc3d4c", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Беларусь", "Беларусь", "2000000097", "Паспорт", "client97@example.com", "Клиент 97", "+7 900 1000097", 0 },
                    { "d5b8ada1-66a5-478a-af81-0b132bb5fefc", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Беларусь", "Беларусь", "2000000009", "Паспорт", "client9@example.com", "Клиент 9", "+7 900 1000009", 0 },
                    { "d655e710-1fd8-43da-b413-f4b1cd944427", "8999674d-e4b9-412d-8030-24abd3e97b68", "Россия", "Россия", "2000000050", "Паспорт", "client50@example.com", "Клиент 50", "+7 900 1000050", 0 },
                    { "dbdf09f4-e7d6-41e2-95d0-4fcb918751d4", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Россия", "Россия", "2000000030", "Паспорт", "client30@example.com", "Клиент 30", "+7 900 1000030", 0 },
                    { "dff451a7-b1aa-435c-9c09-ac95f39893f8", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Беларусь", "Беларусь", "2000000087", "Паспорт", "client87@example.com", "Клиент 87", "+7 900 1000087", 0 },
                    { "e10db667-4e00-4fab-a18b-ad3a01b5def6", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Россия", "Россия", "2000000090", "Паспорт", "client90@example.com", "Клиент 90", "+7 900 1000090", 0 },
                    { "e2e1eaef-b0a3-4e15-93f4-4ec3d27c9920", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Россия", "Россия", "2000000054", "Паспорт", "client54@example.com", "Клиент 54", "+7 900 1000054", 0 },
                    { "e2eeb229-6154-4e21-86ca-6b630a50567c", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Россия", "Россия", "2000000052", "Паспорт", "client52@example.com", "Клиент 52", "+7 900 1000052", 0 },
                    { "e94a084e-7f0a-403b-8e67-c47d28cd67ae", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Россия", "Россия", "2000000012", "Паспорт", "client12@example.com", "Клиент 12", "+7 900 1000012", 0 },
                    { "eb9090be-86ff-4a66-9230-bc5b67363407", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Беларусь", "Беларусь", "2000000079", "Паспорт", "client79@example.com", "Клиент 79", "+7 900 1000079", 0 },
                    { "ee2a0d3b-6fe2-4090-9ca7-df673e23efcf", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Россия", "Россия", "2000000004", "Паспорт", "client4@example.com", "Клиент 4", "+7 900 1000004", 0 },
                    { "eecc97ed-f148-4654-a158-e99ff7c2502b", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Россия", "Россия", "2000000024", "Паспорт", "client24@example.com", "Клиент 24", "+7 900 1000024", 0 },
                    { "f7217748-8c88-46c7-84ce-29287177961f", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Беларусь", "Беларусь", "2000000015", "Паспорт", "client15@example.com", "Клиент 15", "+7 900 1000015", 0 },
                    { "f8e9e253-84f3-47cb-9d4e-384be4b3ffa4", "8999674d-e4b9-412d-8030-24abd3e97b68", "Беларусь", "Беларусь", "2000000083", "Паспорт", "client83@example.com", "Клиент 83", "+7 900 1000083", 0 },
                    { "f934dfa3-b9db-4bdf-98c5-59b1e280616e", "8999674d-e4b9-412d-8030-24abd3e97b68", "Беларусь", "Беларусь", "2000000041", "Паспорт", "client41@example.com", "Клиент 41", "+7 900 1000041", 0 },
                    { "f9764da9-612a-4548-bd45-38717d71040b", "6cf938d0-fa36-44e6-9f59-348b08cc61e9", "Беларусь", "Беларусь", "2000000013", "Паспорт", "client13@example.com", "Клиент 13", "+7 900 1000013", 0 },
                    { "fa6afe7f-3069-461f-b26f-6b63952d494c", "8999674d-e4b9-412d-8030-24abd3e97b68", "Россия", "Россия", "2000000038", "Паспорт", "client38@example.com", "Клиент 38", "+7 900 1000038", 0 },
                    { "ff0d6e7b-48a6-4b24-8ec7-c2e7fa170dc6", "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", "Беларусь", "Беларусь", "2000000093", "Паспорт", "client93@example.com", "Клиент 93", "+7 900 1000093", 0 }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "Balance", "BankId", "IsBlocked", "OwnerId" },
                values: new object[,]
                {
                    { "00768863-2f8b-4860-96da-e825f23bdd0a", "30000103", 1711m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "e2eeb229-6154-4e21-86ca-6b630a50567c" },
                    { "01b3b44e-b836-4fa1-ae18-698683bd262e", "30000162", 584m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "215a46bf-1578-4528-9638-df189437ee5e" },
                    { "01e84d5b-ded9-4668-af7c-dff01bd86779", "30000131", 628m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "d32f8dab-6e79-4e02-897f-4ecbaca02fa9" },
                    { "0205cc72-2df3-4b69-9244-4dbee0c39a27", "30000171", 1963m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "b5c1ff10-0a93-4b22-b56d-0fb614f6c84e" },
                    { "0366ea25-c490-4a3e-868e-1f6f72e9af9c", "30000149", 878m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "0d86112c-2b25-499e-b106-b7db121be61c" },
                    { "043e2c7a-477b-4f01-bed3-eb6cf5a83c29", "30000096", 4545m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "5693d9c4-9485-4aaa-b6fc-6a5ab861af40" },
                    { "068dba1a-d876-45e5-a959-6ab58c24f2b4", "30000042", 3305m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "8c674177-23f4-4151-9605-b73645c8afcf" },
                    { "072bd959-cfac-46b6-9f6b-64390fa8011e", "30000054", 1048m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "acd659b9-cfd5-42c4-8e0b-b7b60d4ffa5a" },
                    { "08dfe43c-29e1-483b-9745-c8e9353004cf", "30000012", 2335m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "08094b0d-d030-4162-9abc-1f030eca614d" },
                    { "09972611-77ea-4327-a6d1-1cd614d90dbe", "30000092", 546m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "61b26fa9-bc00-4917-b61e-566fc706c2b5" },
                    { "0a4dfd22-0a2c-4333-809d-660e716f9be2", "30000114", 1527m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "93968440-2899-4d17-bd12-aa9cd79b2dbb" },
                    { "0e2889fd-7646-4f4f-903a-110236806a1c", "30000155", 4858m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "a5f5b695-3231-4c0b-aa08-1f483e6cec70" },
                    { "0f3b7c64-e46a-47ab-bd51-7252599f2428", "30000069", 3613m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "40af1c11-0666-40ce-96b8-e22fd427eea6" },
                    { "1170e391-b7a1-4d4b-99b7-9f71b7e63e47", "30000140", 4898m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "c62b247e-89ec-408d-82f5-b102f59b60ef" },
                    { "119935ee-a050-4870-b962-f825115f2721", "30000115", 4573m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "9ee081d2-3f1c-4185-af72-0686a573648b" },
                    { "13269930-b50e-4cff-97b1-79e1d731abaa", "30000051", 2854m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "36bce292-c863-4dbc-aef3-5ca0c85b8440" },
                    { "13d64776-a3fa-4647-8336-cf834753a4a6", "30000052", 957m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "36bce292-c863-4dbc-aef3-5ca0c85b8440" },
                    { "140206ac-8a79-4abe-aff8-84bcb30cbc80", "30000099", 4069m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "d655e710-1fd8-43da-b413-f4b1cd944427" },
                    { "1493a1a0-5074-44e2-a5d0-2f2415137677", "30000067", 600m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "b25d01ec-9ada-46e0-8a18-8909f6343e28" },
                    { "150c980d-bc1c-45de-99f4-ad8e6c51f194", "30000195", 2963m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "0082d1aa-a439-4ed7-8c38-baeba06c6c81" },
                    { "15c40b76-6ad9-4091-a35f-d374b0aeca2e", "30000128", 545m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "c6efbf02-b733-4ea6-aaed-215afa5d7027" },
                    { "15facacb-818e-42fd-ac14-704b90a3d189", "30000087", 4587m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "c490632d-1903-422d-9ddf-dc058f19f9e9" },
                    { "16193d6e-a4bf-49c6-922a-5f6c5f563803", "30000055", 4682m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "056e91f1-f205-45ae-8178-359729f37564" },
                    { "163f167c-14cb-423f-ac7d-8439491e185b", "30000015", 3510m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "5f11cad2-b6b2-4054-ac12-a806676daae8" },
                    { "17dd98e4-eb9e-475d-bc49-689b1bef075e", "30000154", 4467m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "59c88718-9d20-4498-9765-33b3a7a843ff" },
                    { "19cc0079-52df-4836-bff2-4904b3b9a6bb", "30000097", 2636m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "27a0997f-a4f9-4dac-8337-7e3d4e97eeb1" },
                    { "1b51a5b3-54e2-44f5-9809-d7975505e526", "30000016", 2754m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "5f11cad2-b6b2-4054-ac12-a806676daae8" },
                    { "1d1352de-3c4b-457f-9176-11ece9405df5", "30000003", 2133m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "af9fe7f9-c8a6-4c3c-b909-27c008a2b4e6" },
                    { "20bb478a-f560-4cd0-a5fa-b9233bd33b90", "30000077", 1223m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "a8e8c1ee-2a71-4ef7-84cc-009293302f3b" },
                    { "220a3006-1903-4f57-a1db-849bbfd5a8f8", "30000005", 3205m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "35f2e909-e077-444a-9d0f-29da02e2e3aa" },
                    { "2259b704-9bee-4b06-9b39-5eba809b5bf0", "30000113", 4240m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "93968440-2899-4d17-bd12-aa9cd79b2dbb" },
                    { "2672d005-af24-4990-94be-e6275fc3ad3d", "30000095", 1988m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "5693d9c4-9485-4aaa-b6fc-6a5ab861af40" },
                    { "268d8cc2-addc-40ca-80d1-42825f5eaa10", "30000119", 535m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "76d5fa37-36e7-46c4-9b54-5925273eb659" },
                    { "2849d826-2767-4693-b7e0-e91f2cb8620d", "30000022", 3871m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "0540ce4e-5d02-499e-97dd-2c5b6283179b" },
                    { "29250dc7-24c5-4c41-86bb-f7a47047dd0a", "30000010", 1091m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "7a4c6e37-cdc3-49c7-85b1-f12c9fd4ba53" },
                    { "2a59ec04-b7cc-4976-a273-1c9632b81dde", "30000159", 4738m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "a4544368-0906-4924-a171-72612f4ff877" },
                    { "2ba312dd-5782-4819-8495-e272b6f1ad03", "30000148", 4155m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "895a2040-ece5-4f6b-8a7f-ca484827abc1" },
                    { "2c89f025-ea06-4067-a901-b6a7a8b891f7", "30000072", 4664m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "67cb388b-cc4e-4e95-bbd9-33474b7088ca" },
                    { "2d7b133c-571c-4199-a7d2-d5452c30f31e", "30000035", 4960m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "5431e1f9-d8db-4a9d-af87-18c9b19a2b20" },
                    { "2e56c211-1c67-4061-9641-fb3599015af1", "30000041", 2862m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "8c674177-23f4-4151-9605-b73645c8afcf" },
                    { "2e5a8272-3f47-445e-8cce-f930a14d23c1", "30000073", 3251m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "4af5e545-757f-4d20-98f6-9cfd33032fa7" },
                    { "2ef03757-9005-406a-bd5a-3f0b0df65c4f", "30000139", 993m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "c62b247e-89ec-408d-82f5-b102f59b60ef" },
                    { "2f6fbd71-60a5-48e7-88b2-f887dfe36d06", "30000193", 1735m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "d4457e8b-9067-43bb-b9c2-620621bc3d4c" },
                    { "3042eb89-6cc6-40d0-9606-22387e519d29", "30000123", 4282m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "225d8d7b-292f-4068-9b56-d7956fab6f14" },
                    { "30b3fe2d-9033-4fb6-a873-806399748c0b", "30000075", 2137m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "fa6afe7f-3069-461f-b26f-6b63952d494c" },
                    { "32b0694c-4d79-48eb-b884-f43159498895", "30000132", 1734m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "d32f8dab-6e79-4e02-897f-4ecbaca02fa9" },
                    { "336e3cf7-379a-439d-b686-dd576b0a9bde", "30000058", 4387m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "a3b40672-37ee-44b3-8d9d-cd57de6d7dfe" },
                    { "33be2464-84dc-4618-a407-ac6a8bb9e739", "30000192", 1987m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "50389981-fd4c-420a-98df-669ae66c3e66" },
                    { "35034e56-2e50-4a49-8fe5-eeccff187c26", "30000147", 949m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "895a2040-ece5-4f6b-8a7f-ca484827abc1" },
                    { "39490ad4-9405-4311-9f99-7806d60675d9", "30000194", 2469m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "d4457e8b-9067-43bb-b9c2-620621bc3d4c" },
                    { "3aebf05c-f2db-4f73-ab03-bac4dfcb0dc4", "30000125", 2413m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "9d146c19-4708-4cca-8725-59acb79de945" },
                    { "3c49c33e-fd7b-4c5d-a3d3-7e98365b02f5", "30000196", 1045m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "0082d1aa-a439-4ed7-8c38-baeba06c6c81" },
                    { "3d5f99be-0581-4471-9140-29fb5d6bb018", "30000009", 4737m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "7a4c6e37-cdc3-49c7-85b1-f12c9fd4ba53" },
                    { "3e3bd19d-dc08-4f0a-a302-05ea194df8cb", "30000122", 1225m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "3d4d309f-5493-4d9e-969d-fa5ad03c8690" },
                    { "3f59e1e3-7921-4c62-b55a-c3b660c4c4b4", "30000143", 4147m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "0dac40b7-60a1-4f4a-8c66-2378f748b5ed" },
                    { "4002f289-e880-419b-a5fb-8dbb3a29caf8", "30000063", 2898m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "b0b14a84-9815-4545-87ad-b3fde41e36c5" },
                    { "41f4b775-b221-400f-8fc1-64b1d919b9e7", "30000071", 2177m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "67cb388b-cc4e-4e95-bbd9-33474b7088ca" },
                    { "459a69d9-c1a1-4007-9900-764fb4d96edf", "30000036", 1257m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "5431e1f9-d8db-4a9d-af87-18c9b19a2b20" },
                    { "46264484-85c0-4351-8a60-9e851d5c2cf3", "30000081", 4842m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "f934dfa3-b9db-4bdf-98c5-59b1e280616e" },
                    { "48457963-3065-48ed-a028-27238cad0070", "30000086", 3983m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "2351af36-55ff-4d94-a477-6fc00f6e5457" },
                    { "4a2e748d-b2ba-4ba5-a9c2-b5aa30dfdde8", "30000142", 691m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "73223ae1-46c4-4d19-a61e-0dfb49774955" },
                    { "4c4f99a7-a026-462f-9ee5-a017d3d21093", "30000020", 2253m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "392d93a0-a16e-44d1-b783-05fdac6eec4c" },
                    { "4dbe7e1a-0381-4525-9fc2-d976eea9064b", "30000039", 855m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "286f5579-4e1a-42e1-9344-62205054c024" },
                    { "4e99521b-d542-419d-abf4-86d86fec68d8", "30000031", 2494m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "982efc99-db62-423a-9c90-3b15a1e1514e" },
                    { "4f6de6cb-2c78-4a10-8117-aa4c98be8632", "30000038", 920m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "3292cd57-5f4d-4ccc-87d4-1577ea3b31af" },
                    { "50f42f3d-d91d-4834-9425-3faeabdca9f1", "30000152", 2939m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "935bd585-f9f4-4ac4-a77b-7af0c1c55f16" },
                    { "51417e73-f844-40e6-bfab-d3e85230550e", "30000040", 4773m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "286f5579-4e1a-42e1-9344-62205054c024" },
                    { "51735b43-0747-4270-ae0a-8ef3aae59935", "30000061", 1064m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "01e93c6a-3d64-4a49-a477-609630a2e0c1" },
                    { "51872da6-f7fc-41a9-aefc-99bce0c1aa2a", "30000064", 2397m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "b0b14a84-9815-4545-87ad-b3fde41e36c5" },
                    { "54284bea-6f80-40b6-8804-08cec97f01e4", "30000046", 2254m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "4493f76c-55b2-4664-a694-752ae2b2e2fc" },
                    { "576473a3-9e94-41e3-b863-8357965667ba", "30000177", 1281m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "2745294f-d849-4f70-a545-4f76955d1aa5" },
                    { "58211388-d4fe-447d-aaf4-bf5708cda2e0", "30000059", 1556m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "dbdf09f4-e7d6-41e2-95d0-4fcb918751d4" },
                    { "5994cef2-7b81-47ca-872e-f1a585ac347f", "30000083", 2794m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "0c9daf27-240e-489e-a7af-ea4de0037b90" },
                    { "5d5fce88-ec7b-488e-b047-b7ac01e4d91e", "30000074", 1881m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "4af5e545-757f-4d20-98f6-9cfd33032fa7" },
                    { "60b5b586-f180-428a-8e50-fdf345049caf", "30000189", 4383m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "023d0b08-d772-4675-a08f-954034564cf5" },
                    { "63c3d196-8985-4dc6-bdaf-a9693467754a", "30000181", 3996m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "18c1a89e-2542-4fcd-8c0a-9276fe632726" },
                    { "63cd222d-5620-40d7-ad07-76416a4d2672", "30000062", 1816m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "01e93c6a-3d64-4a49-a477-609630a2e0c1" },
                    { "68042f7d-a9a7-4187-8c5f-15e176b10cf4", "30000176", 2610m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "57217908-5b64-45bc-aae3-b81141b03edf" },
                    { "692d8a8c-a635-4b97-b2f0-465e7920ae39", "30000098", 4571m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "27a0997f-a4f9-4dac-8337-7e3d4e97eeb1" },
                    { "69c02557-a5e1-4fce-ac4e-2aff7b3726e0", "30000024", 4030m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "e94a084e-7f0a-403b-8e67-c47d28cd67ae" },
                    { "69da1970-e570-4bc5-ac93-00cf4b41a1d2", "30000014", 4212m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "84b43a14-4060-4672-ac1d-2bade002c71c" },
                    { "6bbb1e01-014d-40bb-a334-49c9f77cbefd", "30000183", 4667m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "a923c3ba-7b4e-4490-a549-bc523dd1ca6f" },
                    { "6d32304a-501d-4d80-bb67-4cc1f86e0933", "30000082", 4825m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "f934dfa3-b9db-4bdf-98c5-59b1e280616e" },
                    { "73172f23-721d-42b3-a820-7a1c67132356", "30000068", 3926m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "b25d01ec-9ada-46e0-8a18-8909f6343e28" },
                    { "737c7506-af08-4fe3-843f-ff1702ea6ebe", "30000080", 4709m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "4b099cca-847e-48a8-9308-bce74338bb90" },
                    { "756fbb95-16d1-443d-97e1-892ea8e38169", "30000150", 2059m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "0d86112c-2b25-499e-b106-b7db121be61c" },
                    { "76645e61-7a5e-44c3-81a7-6de8aeb06b6f", "30000079", 1221m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "4b099cca-847e-48a8-9308-bce74338bb90" },
                    { "77feeb56-5987-4fb4-94ba-1af8746a55d7", "30000137", 4169m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "8127e86b-a015-49e6-b67f-095fc3c7f58d" },
                    { "7970a6be-f0cd-4143-a745-ae350a9b12a0", "30000110", 902m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "baf7d35a-24da-4be1-9126-39bd867385c9" },
                    { "797d453c-769a-438f-92d8-88732cee233a", "30000056", 3836m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "056e91f1-f205-45ae-8178-359729f37564" },
                    { "7a2fc156-b5c6-415c-8d3d-d8d78923c05b", "30000158", 2506m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "eb9090be-86ff-4a66-9230-bc5b67363407" },
                    { "7a7fa36a-8da2-440f-8123-0844a507a286", "30000185", 1910m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "ff0d6e7b-48a6-4b24-8ec7-c2e7fa170dc6" },
                    { "7b71a99f-3108-4b11-998d-b0c8c3233cff", "30000106", 3487m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "abb68796-3538-46e2-8a15-a15a9102a25e" },
                    { "7c0844db-8d5a-44e7-b357-fae014130b4f", "30000121", 1123m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "3d4d309f-5493-4d9e-969d-fa5ad03c8690" },
                    { "7eac7fdc-8e2d-4191-8a28-860f3d9f7397", "30000112", 2333m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "2a9b9a4d-e732-4f27-a4c3-9add97e8933a" },
                    { "7f4ae2b3-5192-48d8-8fed-1108840d2c63", "30000180", 996m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "e10db667-4e00-4fab-a18b-ad3a01b5def6" },
                    { "7f6b1a54-c975-4769-acd9-d9346f27b8a1", "30000028", 798m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "1799c012-c548-44fc-baac-43482c2835ae" },
                    { "7fa05669-00f1-4027-bd0a-eeee7b172491", "30000179", 2905m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "e10db667-4e00-4fab-a18b-ad3a01b5def6" },
                    { "853a12f7-ec9a-4f22-a0a2-35fb304e22f5", "30000141", 2985m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "73223ae1-46c4-4d19-a61e-0dfb49774955" },
                    { "8769b093-aba9-481f-ab6a-7713359c7978", "30000102", 1368m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "7932d989-611a-48a6-9ed3-68b83f4653ab" },
                    { "87e99ba9-2132-48b0-8caa-f5105119b25f", "30000188", 3489m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "ce835b47-17e4-402a-9206-f8f5f1549bb4" },
                    { "88639793-e659-4878-a715-4d677a0968bc", "30000153", 4969m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "59c88718-9d20-4498-9765-33b3a7a843ff" },
                    { "88d514a9-196e-45d4-a77d-8a6576848c23", "30000047", 4798m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "eecc97ed-f148-4654-a158-e99ff7c2502b" },
                    { "8a1c23b2-c460-4907-9398-9bcd90570993", "30000043", 1153m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "9132f2f1-cb92-4482-aae8-f0bb6daf3cec" },
                    { "8a2e06de-fd2b-432d-8349-0ebb7c20755b", "30000174", 2936m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "dff451a7-b1aa-435c-9c09-ac95f39893f8" },
                    { "8cb69041-3ce0-4c33-a521-35db0185f59a", "30000093", 2930m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "10883b64-b0c3-46c0-959a-c141a2859cb7" },
                    { "8ee2d8a0-2a2f-4864-8969-aef9ebaed0a0", "30000048", 654m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "eecc97ed-f148-4654-a158-e99ff7c2502b" },
                    { "8ee4a1f5-bdc5-4216-af3e-f7d16bf081d7", "30000111", 4376m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "2a9b9a4d-e732-4f27-a4c3-9add97e8933a" },
                    { "91b1aee1-ab23-4ee7-9839-14c64b13c154", "30000090", 4522m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "cc3a157f-dd8e-446d-a3fc-ea3d2c44591a" },
                    { "922e1266-55bb-45cd-a497-e691d504dc00", "30000008", 3003m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "ee2a0d3b-6fe2-4090-9ca7-df673e23efcf" },
                    { "945daaa8-4364-4ae2-a4a6-3a32ad62b21d", "30000108", 4168m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "e2e1eaef-b0a3-4e15-93f4-4ec3d27c9920" },
                    { "97a1f21c-8f93-48cc-9ca8-30b226075863", "30000186", 4711m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "ff0d6e7b-48a6-4b24-8ec7-c2e7fa170dc6" },
                    { "9bf8b69f-ff37-4d78-b043-9fdd0c439235", "30000104", 1769m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "e2eeb229-6154-4e21-86ca-6b630a50567c" },
                    { "9f07dc5f-8453-431b-a2a3-cad95560e0a2", "30000134", 2575m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "43895ee0-6d0f-43cc-93f4-1602782858f1" },
                    { "9f28a861-2493-45fa-97a1-aa95fe315c39", "30000165", 3059m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "f8e9e253-84f3-47cb-9d4e-384be4b3ffa4" },
                    { "9f3e7594-33d5-4a76-b0d8-46b299f79a29", "30000129", 2941m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "18825c4b-f141-48ef-a2fd-f28cb3144011" },
                    { "a225c188-ace5-4b3b-8eee-89899a02b325", "30000057", 540m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "a3b40672-37ee-44b3-8d9d-cd57de6d7dfe" },
                    { "a328da8c-c04a-4c67-9db5-5a3d05880bf9", "30000109", 3560m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "baf7d35a-24da-4be1-9126-39bd867385c9" },
                    { "a405187b-1afc-4999-b5aa-630bc0c05d8f", "30000157", 4426m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "eb9090be-86ff-4a66-9230-bc5b67363407" },
                    { "a5c5b3da-3483-463c-a5b7-6bde9f8f5db2", "30000017", 3443m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "d5b8ada1-66a5-478a-af81-0b132bb5fefc" },
                    { "a626b5ad-be14-4cbe-9705-2456f8b3d35b", "30000002", 4092m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "47259eb4-f721-4c9c-a400-a4daa026a1ae" },
                    { "a73d0334-428b-408c-8ef9-079b7034c7c9", "30000116", 1261m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "9ee081d2-3f1c-4185-af72-0686a573648b" },
                    { "a7fd5f02-1a96-464c-b8e7-27fb64e6f81c", "30000120", 3255m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "76d5fa37-36e7-46c4-9b54-5925273eb659" },
                    { "aa20e0b2-022e-47d2-b36c-2898d5245ed5", "30000117", 658m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "796ff407-7b51-4866-ba2a-431c6ad6b1bf" },
                    { "aad92956-f458-4959-a6d5-bcff58e77e20", "30000001", 1131m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "47259eb4-f721-4c9c-a400-a4daa026a1ae" },
                    { "ab2b7579-29cf-4e46-aedf-4ea528b1a7d0", "30000200", 4509m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "2139fc35-0078-4320-9581-78a29a872a39" },
                    { "ad69caeb-d75d-4741-8c53-2531bf91c4f5", "30000060", 3638m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "dbdf09f4-e7d6-41e2-95d0-4fcb918751d4" },
                    { "ada80052-a0da-4f42-8d4e-a22ed4ccc543", "30000107", 3081m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "e2e1eaef-b0a3-4e15-93f4-4ec3d27c9920" },
                    { "ade0e114-fda5-4a0b-ad42-71fef33c94d7", "30000182", 4184m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "18c1a89e-2542-4fcd-8c0a-9276fe632726" },
                    { "aeb591db-041f-4bb6-8e57-0dc8fee78331", "30000023", 2067m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "e94a084e-7f0a-403b-8e67-c47d28cd67ae" },
                    { "afd19315-a6db-46b9-94cd-f23b92c3031d", "30000006", 731m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "35f2e909-e077-444a-9d0f-29da02e2e3aa" },
                    { "b09b7b18-1483-48c0-947b-4c4a644fd144", "30000034", 3397m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "9eaaf08f-a1be-4d7f-987b-5861a321ad6f" },
                    { "b2a9884b-cdcd-42c6-8441-66d3743982f9", "30000050", 692m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "ce0f68c7-8d8e-45f1-a054-5f9c97c4cf64" },
                    { "b2cef388-f039-4117-8330-40e15550fa02", "30000191", 655m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "50389981-fd4c-420a-98df-669ae66c3e66" },
                    { "b3323a5a-74fa-420f-9edf-792979af4d89", "30000065", 2839m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "08e21d69-c725-42b4-a68b-043728e9148e" },
                    { "b3eb6e13-666f-4061-9334-fc19c723b3bf", "30000164", 2103m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "7f2a8d5b-dd9e-49f1-bb1f-77ad1ed48ede" },
                    { "b623254c-f52c-43b3-aa39-d96a2ad6d5d2", "30000160", 4211m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "a4544368-0906-4924-a171-72612f4ff877" },
                    { "b654e8a0-adc6-4020-a76b-2b84fd778439", "30000169", 2356m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "3cdabfd5-445e-40b9-9f5a-38087f3d4e34" },
                    { "b74a4275-d2d8-4230-8d63-9119cea6732c", "30000170", 1227m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "3cdabfd5-445e-40b9-9f5a-38087f3d4e34" },
                    { "b8d6861e-f85b-478e-b657-d0c0a25f6cf3", "30000066", 1434m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "08e21d69-c725-42b4-a68b-043728e9148e" },
                    { "ba397516-1c82-4382-87ae-6326b5a4aabc", "30000146", 4144m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "5796b0a5-116b-4bcd-be1b-962e9cdfda7c" },
                    { "bd0e4dcd-c140-4bfd-8109-a68d8743e07a", "30000118", 1064m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "796ff407-7b51-4866-ba2a-431c6ad6b1bf" },
                    { "bdd3ff5b-ea98-4158-81ae-f0824608daba", "30000049", 4670m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "ce0f68c7-8d8e-45f1-a054-5f9c97c4cf64" },
                    { "be4fb777-8003-477b-baef-5395d3180e4f", "30000161", 3538m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "215a46bf-1578-4528-9638-df189437ee5e" },
                    { "be7b3944-3ac6-471a-8e0c-541b0cbd4215", "30000151", 4133m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "935bd585-f9f4-4ac4-a77b-7af0c1c55f16" },
                    { "be9b3afb-41de-409d-b838-1381ffde7ca3", "30000045", 2370m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "4493f76c-55b2-4664-a694-752ae2b2e2fc" },
                    { "c1e7d719-a0da-48bf-98b5-ff9c9c3d99ed", "30000101", 3719m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "7932d989-611a-48a6-9ed3-68b83f4653ab" },
                    { "c295c315-58dd-4c19-a68c-9ef7e3c775e9", "30000130", 4118m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "18825c4b-f141-48ef-a2fd-f28cb3144011" },
                    { "c3d0d19c-988e-4f29-a674-d16f45541a48", "30000163", 1359m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "7f2a8d5b-dd9e-49f1-bb1f-77ad1ed48ede" },
                    { "c681c0c0-3dc1-48f7-b6bf-501d1ac16dd6", "30000033", 4945m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "9eaaf08f-a1be-4d7f-987b-5861a321ad6f" },
                    { "c6ce9bca-d51c-4ebf-ba20-c7d8c832b6ab", "30000025", 4883m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "f9764da9-612a-4548-bd45-38717d71040b" },
                    { "c7fd6874-1148-411b-9d9d-7845bd86c8a3", "30000190", 1042m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "023d0b08-d772-4675-a08f-954034564cf5" },
                    { "c9420acb-8853-40c0-9433-d17de500c930", "30000004", 2864m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "af9fe7f9-c8a6-4c3c-b909-27c008a2b4e6" },
                    { "ca3984ea-56b1-4c02-898d-6e3e4007c797", "30000085", 1743m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "2351af36-55ff-4d94-a477-6fc00f6e5457" },
                    { "ce3d4ed2-5f60-4361-a52b-a4b55e6a28fe", "30000105", 771m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "abb68796-3538-46e2-8a15-a15a9102a25e" },
                    { "cecf511b-696e-4835-9161-5c0e9bd2ecb7", "30000088", 4594m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "c490632d-1903-422d-9ddf-dc058f19f9e9" },
                    { "cf59e189-43fa-480d-95f2-a3dc9a485c13", "30000076", 916m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "fa6afe7f-3069-461f-b26f-6b63952d494c" },
                    { "cf6cb3d5-9478-4c08-bda0-612cd73d3795", "30000021", 4051m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "0540ce4e-5d02-499e-97dd-2c5b6283179b" },
                    { "d0f49325-f0b3-4e07-a797-65deb44ad434", "30000197", 3685m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "d2296f9c-3334-4248-8d51-f95e59785d61" },
                    { "d22c4a10-2674-41e9-9aa4-e1f4c9c5336c", "30000053", 1274m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "acd659b9-cfd5-42c4-8e0b-b7b60d4ffa5a" },
                    { "d231f78a-686c-4d54-90fe-348ed1f159ce", "30000133", 3024m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "43895ee0-6d0f-43cc-93f4-1602782858f1" },
                    { "d2bf49e7-264a-4ac3-95b6-b5153fa4a2b3", "30000136", 1750m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "a8b588b0-3473-4663-ae44-e10fe046ed2c" },
                    { "d36948b6-8874-4ce0-a55d-de63915deec2", "30000127", 4625m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "c6efbf02-b733-4ea6-aaed-215afa5d7027" },
                    { "d54ad617-aec0-46aa-bfe1-caed265f4fb0", "30000011", 4059m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "08094b0d-d030-4162-9abc-1f030eca614d" },
                    { "d5cc84e1-a820-476d-b9b8-7108d379b235", "30000198", 4903m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "d2296f9c-3334-4248-8d51-f95e59785d61" },
                    { "d68ac3c1-9b21-44f3-905f-981b892eb87b", "30000027", 2836m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "1799c012-c548-44fc-baac-43482c2835ae" },
                    { "d69469a0-a491-427e-b253-5dad3bbebc20", "30000032", 4657m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "982efc99-db62-423a-9c90-3b15a1e1514e" },
                    { "d6ec2a1a-ff77-4023-8462-43dcbe337231", "30000167", 4128m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "c8f0c5a4-3c04-4ea6-85bf-a0627a694916" },
                    { "d7cd879a-d0df-4b8d-b222-099379cf2a34", "30000018", 1986m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "d5b8ada1-66a5-478a-af81-0b132bb5fefc" },
                    { "d8aadbec-0b44-403a-985c-18203ff51727", "30000029", 4029m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "f7217748-8c88-46c7-84ce-29287177961f" },
                    { "d939fe2f-5f5c-4704-958b-2128054f6a85", "30000013", 3662m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "84b43a14-4060-4672-ac1d-2bade002c71c" },
                    { "d9ba6b53-4fce-415e-bb27-6914e138b162", "30000168", 2609m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "c8f0c5a4-3c04-4ea6-85bf-a0627a694916" },
                    { "d9f3dd5a-941e-436d-9463-b29acec86565", "30000175", 3666m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "57217908-5b64-45bc-aae3-b81141b03edf" },
                    { "dcac4048-8d85-4c62-b448-30fdf5cd7c13", "30000135", 566m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "a8b588b0-3473-4663-ae44-e10fe046ed2c" },
                    { "dcd4ae6f-27f4-4a0d-ad72-4e12827fbcdf", "30000007", 4581m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "ee2a0d3b-6fe2-4090-9ca7-df673e23efcf" },
                    { "dce33667-ce18-4ea4-b6cd-d44b72b84fab", "30000173", 3051m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "dff451a7-b1aa-435c-9c09-ac95f39893f8" },
                    { "de5dcac9-20d1-42ee-b411-c3020cfb1a85", "30000100", 2837m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "d655e710-1fd8-43da-b413-f4b1cd944427" },
                    { "e0ba4605-3c5e-4a64-86f8-a9b4f5587ef3", "30000187", 2104m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "ce835b47-17e4-402a-9206-f8f5f1549bb4" },
                    { "e1ecfcb4-85fe-4686-aef5-228d3a90b9bd", "30000166", 1736m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "f8e9e253-84f3-47cb-9d4e-384be4b3ffa4" },
                    { "e6114c04-aa41-4a65-9d64-bff2384412b4", "30000199", 1511m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "2139fc35-0078-4320-9581-78a29a872a39" },
                    { "e6e1f0c1-63ae-4e18-be39-a0738b71901d", "30000037", 2622m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "3292cd57-5f4d-4ccc-87d4-1577ea3b31af" },
                    { "e77d5ee9-f8a9-47df-a3cd-32fcd8cfda9c", "30000089", 4146m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "cc3a157f-dd8e-446d-a3fc-ea3d2c44591a" },
                    { "e7b3abba-c185-4f1e-888d-76137693316b", "30000172", 3069m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "b5c1ff10-0a93-4b22-b56d-0fb614f6c84e" },
                    { "e8beb09b-e82c-4df2-aa6f-2daad2d72b43", "30000124", 891m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "225d8d7b-292f-4068-9b56-d7956fab6f14" },
                    { "ec459ab1-eeea-40a3-9099-8bd4dd0a164c", "30000138", 2736m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "8127e86b-a015-49e6-b67f-095fc3c7f58d" },
                    { "ec4f67ad-1b51-425d-9a05-a4e4e26ac7f4", "30000178", 540m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "2745294f-d849-4f70-a545-4f76955d1aa5" },
                    { "ef98689e-ac51-4d92-a0f9-904e0cf164ac", "30000070", 4192m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "40af1c11-0666-40ce-96b8-e22fd427eea6" },
                    { "effba17b-8596-49c2-9181-08806a40e4f2", "30000156", 2270m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "a5f5b695-3231-4c0b-aa08-1f483e6cec70" },
                    { "f2c98e17-c9b3-491f-87f1-541dcdd94748", "30000091", 1788m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "61b26fa9-bc00-4917-b61e-566fc706c2b5" },
                    { "f4f43b4b-3987-4828-8d8f-3be6cc5a42e4", "30000145", 2643m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "5796b0a5-116b-4bcd-be1b-962e9cdfda7c" },
                    { "f6c85537-a5e7-4288-8ebf-7349cdcb38fe", "30000044", 2146m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "9132f2f1-cb92-4482-aae8-f0bb6daf3cec" },
                    { "f75ae652-10ba-4573-801f-3cc5fd9da90f", "30000144", 3037m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "0dac40b7-60a1-4f4a-8c66-2378f748b5ed" },
                    { "f885670e-20db-4029-bf14-57ceb12f9790", "30000026", 1166m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "f9764da9-612a-4548-bd45-38717d71040b" },
                    { "f96466da-380d-4dde-9b4d-7765fbf10a81", "30000094", 1500m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "10883b64-b0c3-46c0-959a-c141a2859cb7" },
                    { "f9b3f6ae-702c-4a35-84ba-bd9347a11938", "30000078", 723m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "a8e8c1ee-2a71-4ef7-84cc-009293302f3b" },
                    { "fae9f38e-02bb-4e39-9f06-2e72afa8e777", "30000030", 1561m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "f7217748-8c88-46c7-84ce-29287177961f" },
                    { "faf17f2f-662f-4d2b-9e08-231e45c10e55", "30000184", 641m, "8999674d-e4b9-412d-8030-24abd3e97b68", false, "a923c3ba-7b4e-4490-a549-bc523dd1ca6f" },
                    { "fd3849b3-3ff1-458b-be24-aa7dfc84e7b8", "30000084", 4854m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "0c9daf27-240e-489e-a7af-ea4de0037b90" },
                    { "fd6b5647-cec3-485c-9714-56dc7f0dfef8", "30000126", 4575m, "33c7d22d-541c-41d2-ba66-c5fe5e6c8781", false, "9d146c19-4708-4cca-8725-59acb79de945" },
                    { "ff312a5d-1186-47d4-8dd0-042a36f51330", "30000019", 3803m, "6cf938d0-fa36-44e6-9f59-348b08cc61e9", false, "392d93a0-a16e-44d1-b783-05fdac6eec4c" }
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
