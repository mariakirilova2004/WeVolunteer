using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeVolunteer.Infrastructure.Migrations
{
    public partial class AddedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0124e86e-b185-422a-a662-d88c325712b7", "AQAAAAEAACcQAAAAENwN9lryqkaw6SVRzRkWp5LN6YNVIUXrxEgBbZMa1Zx7+znIOLcufa2bA6lh3el7ng==", "86cc400f-b22f-4fea-a914-2f6f3c93bf8a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9893a77-205d-4cee-b6d5-c51049cf0485", "AQAAAAEAACcQAAAAENx7YZ4crnnW30Dip/XJQxnGmllKE1RZ1hF/rV5nJDe4yndAt4deCpbnuD+vtik/fw==", "fbef33f0-c147-4dc4-82a9-d03664ab195c" });
        }
    }
}
