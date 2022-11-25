using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeVolunteer.Infrastructure.Migrations
{
    public partial class AddUserNameToUserov : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "e7ee05fd-3425-44d7-bab0-e4c83ca409fc", "USERQ", "AQAAAAEAACcQAAAAEC//1YFtPgw2RhUB0avui0eCC27dLRt1Mz4qwmJEMXoApn2p14MkFkukt0QTP5wRFA==", "59e4f1e7-f3ec-4860-884e-3911ad6b1515", "USERQ" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "3c037a5e-d5e4-485a-bddd-6cc4ce029433", null, "AQAAAAEAACcQAAAAEBB0NnLm+dK2u+gvFZ4ogmvOtsBfbMQscE9xsQ7QgA6Rv+MuhhlZQ8wP6fF5d/sA+A==", "22ab4b95-6b55-47af-8a60-6a8251f5be39", null });
        }
    }
}
