using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeVolunteer.Infrastructure.Migrations
{
    public partial class AddedAdminNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856 - c198 - 4129 - b3f3 - b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5dd4e87-e40a-455a-bf5e-5ee4d40a4eec", "AQAAAAEAACcQAAAAEMDY1p/XpQqlLz1JSYksmMwecyJ644S2nuBx5R0nc4AmWhUjofusxETe9WbF+tVUAA==", "06dd867d-a8a1-4359-9de2-82dc0b800b0a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856 - c198 - 4129 - b3f3 - b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77265ce8-5120-4cc1-80ef-6528ccbe23fc", "AQAAAAEAACcQAAAAELSrMy6MDb9snnVImbqxG+wSn9AErRhL7WtFmGm6cWdl/I02NN4dG8xZ/xs/4yA4bA==", "ef4bf985-ebf7-41fe-8d30-570a295e992f" });
        }
    }
}
