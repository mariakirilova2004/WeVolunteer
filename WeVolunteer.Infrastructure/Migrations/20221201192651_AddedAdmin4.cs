using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeVolunteer.Infrastructure.Migrations
{
    public partial class AddedAdmin4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856 - c198 - 4129 - b3f3 - b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77265ce8-5120-4cc1-80ef-6528ccbe23fc", "AQAAAAEAACcQAAAAELSrMy6MDb9snnVImbqxG+wSn9AErRhL7WtFmGm6cWdl/I02NN4dG8xZ/xs/4yA4bA==", "ef4bf985-ebf7-41fe-8d30-570a295e992f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856 - c198 - 4129 - b3f3 - b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99731446-d2c0-4458-9ee0-8b0579d8dd49", "AQAAAAEAACcQAAAAEOQ0MqN3uufhC3AhwwGHtLfRI99UEWo45mZvCmyruupnsUNBbp0G8mvI8nCkM6gaRg==", "4fe2315e-22db-4980-8b42-b546463398c1" });
        }
    }
}
