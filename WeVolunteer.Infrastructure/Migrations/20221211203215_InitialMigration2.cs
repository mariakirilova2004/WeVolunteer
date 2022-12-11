using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeVolunteer.Infrastructure.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856 - c198 - 4129 - b3f3 - b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d37f4ec7-a94f-4ce4-a99f-ac105e54a624", "AQAAAAEAACcQAAAAEDD12o0PH6LzoDDaexyMkwVdihIxqpf4Ke0eWLsQrGQDQK2Y5pkl/vqjhD5i3F0a/Q==", "e3c982c0-56aa-43df-98f4-8d2b1fdc5e39" });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Description", "Headquarter", "Name", "UserId" },
                values: new object[] { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt.", "Sofia, Bulgaria", "Admin organization", "deal12856 - c198 - 4129 - b3f3 - b893d8395082" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856 - c198 - 4129 - b3f3 - b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b07baf1-09a2-4774-bf65-22654e98c8d3", "AQAAAAEAACcQAAAAEArcIaL4h0zTQ/dC7TXT6Z5jW4cojPPtBNKYjAw50D9WVie59hS6GoKBBYPBDxepFg==", "d74243f4-7682-4b05-a1e9-b5b82a9e8074" });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Description", "Headquarter", "Name", "UserId" },
                values: new object[] { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt.", "Sofia, Bulgaria", "Admin organization", "deal12856 - c198 - 4129 - b3f3 - b893d8395082" });
        }
    }
}
