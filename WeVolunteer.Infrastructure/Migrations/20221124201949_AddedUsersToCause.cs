using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeVolunteer.Infrastructure.Migrations
{
    public partial class AddedUsersToCause : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CauseId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c037a5e-d5e4-485a-bddd-6cc4ce029433", "AQAAAAEAACcQAAAAEBB0NnLm+dK2u+gvFZ4ogmvOtsBfbMQscE9xsQ7QgA6Rv+MuhhlZQ8wP6fF5d/sA+A==", "22ab4b95-6b55-47af-8a60-6a8251f5be39" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CauseId",
                table: "AspNetUsers",
                column: "CauseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Causes_CauseId",
                table: "AspNetUsers",
                column: "CauseId",
                principalTable: "Causes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Causes_CauseId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CauseId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CauseId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95a629b9-b0a5-465f-ace3-0a0db8b6fe63", "AQAAAAEAACcQAAAAEPqy1DRUtrNYeIPkxIok1r1ZkzNohn+zL5UH/2zj/fbFwBuy8ZYz0K146epo2rnBzQ==", "aa744c52-f407-4082-8a74-9108937247af" });
        }
    }
}
