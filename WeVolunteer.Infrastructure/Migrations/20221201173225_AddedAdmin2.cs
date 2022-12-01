using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeVolunteer.Infrastructure.Migrations
{
    public partial class AddedAdmin2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "deal12856 - c198 - 4129 - b3f3 - b893d8395082", 0, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8aea7dde-cae1-490e-8b1d-7e4c466d8bb5", "user@mail.com", false, "User", "Userov", false, null, "USER@MAIL.COM", "USERQ", "AQAAAAEAACcQAAAAEMz9vbfq7bFQ8ndCwe0GVZGTa7IKl+HKgXIZaSxxemgM0/+csbo5YptwoZ/Uk4bpCw==", "0888888888", false, "5ff3e8a1-5cdd-4f9d-a0da-4af657bef1ed", false, "USERQ" });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "deal12856 - c198 - 4129 - b3f3 - b893d8395082");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856 - c198 - 4129 - b3f3 - b893d8395082");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "deal12856-c198-4129-b3f3-b893d8395082", 0, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0124e86e-b185-422a-a662-d88c325712b7", "user@mail.com", false, "User", "Userov", false, null, "USER@MAIL.COM", "USERQ", "AQAAAAEAACcQAAAAENwN9lryqkaw6SVRzRkWp5LN6YNVIUXrxEgBbZMa1Zx7+znIOLcufa2bA6lh3el7ng==", "0888888888", false, "86cc400f-b22f-4fea-a914-2f6f3c93bf8a", false, "USERQ" });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "deal12856-c198-4129-b3f3-b893d8395082");
        }
    }
}
