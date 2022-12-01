using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeVolunteer.Infrastructure.Migrations
{
    public partial class AddedAdmin3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856 - c198 - 4129 - b3f3 - b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99731446-d2c0-4458-9ee0-8b0579d8dd49", "AQAAAAEAACcQAAAAEOQ0MqN3uufhC3AhwwGHtLfRI99UEWo45mZvCmyruupnsUNBbp0G8mvI8nCkM6gaRg==", "4fe2315e-22db-4980-8b42-b546463398c1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856 - c198 - 4129 - b3f3 - b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8aea7dde-cae1-490e-8b1d-7e4c466d8bb5", "AQAAAAEAACcQAAAAEMz9vbfq7bFQ8ndCwe0GVZGTa7IKl+HKgXIZaSxxemgM0/+csbo5YptwoZ/Uk4bpCw==", "5ff3e8a1-5cdd-4f9d-a0da-4af657bef1ed" });
        }
    }
}
