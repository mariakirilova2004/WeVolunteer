using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeVolunteer.Infrastructure.Migrations
{
    public partial class CategoryAddedToCause : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Causes_CauseId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CauseId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CauseId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Causes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4e40bcb-e9d0-4ab4-a3dd-fafbbf67c11f", "AQAAAAEAACcQAAAAEK6N+rFxr5yCDNBEB8p8fYAMHABSx5MKpqPA/7c/JHnf0FXGpwDwi7rzZn2sNYA0Xg==", "688031f0-9dfe-4900-a7e1-f0e552a2d6ba" });

            migrationBuilder.UpdateData(
                table: "Causes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Causes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Causes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Causes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoryId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Causes_CategoryId",
                table: "Causes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Causes_Categories_CategoryId",
                table: "Causes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Causes_Categories_CategoryId",
                table: "Causes");

            migrationBuilder.DropIndex(
                name: "IX_Causes_CategoryId",
                table: "Causes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Causes");

            migrationBuilder.AddColumn<int>(
                name: "CauseId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b9fa53f-d5ce-42d7-9f76-1dc24e827c18", "AQAAAAEAACcQAAAAEOkS8BjwwAJ5Bsgr/BSvsLAF1MOA8zA5e8aWjIuIF4X8c2G4RSk7vqU1B02rUQ9m3Q==", "6c8dd797-e4ad-4e41-a12b-638a78b3cb8f" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CauseId",
                table: "Categories",
                column: "CauseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Causes_CauseId",
                table: "Categories",
                column: "CauseId",
                principalTable: "Causes",
                principalColumn: "Id");
        }
    }
}
