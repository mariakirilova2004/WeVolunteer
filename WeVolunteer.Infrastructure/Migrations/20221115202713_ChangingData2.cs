using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeVolunteer.Infrastructure.Migrations
{
    public partial class ChangingData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b9fa53f-d5ce-42d7-9f76-1dc24e827c18", "AQAAAAEAACcQAAAAEOkS8BjwwAJ5Bsgr/BSvsLAF1MOA8zA5e8aWjIuIF4X8c2G4RSk7vqU1B02rUQ9m3Q==", "6c8dd797-e4ad-4e41-a12b-638a78b3cb8f" });

            migrationBuilder.UpdateData(
                table: "PhotosCauses",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "~/images/1.jpg");

            migrationBuilder.UpdateData(
                table: "PhotosCauses",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "~/images/2.jpg");

            migrationBuilder.UpdateData(
                table: "PhotosCauses",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "~/images/3.jpg");

            migrationBuilder.UpdateData(
                table: "PhotosCauses",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "~/images/4.jpg");

            migrationBuilder.UpdateData(
                table: "PhotosCauses",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "~/images/5.jpg");

            migrationBuilder.UpdateData(
                table: "PhotosOrganizations",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "~/images/Organization.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92a59497-1f98-47ad-a4e1-ede8f020cd63", "AQAAAAEAACcQAAAAEGpbldn6M3+E1igN17LYKSW3BKcQleXcjZzurGcfhWsCrnCYnvdWwq48HXyfEwaJLg==", "8f9ee216-12ad-4e5d-8234-4ddd9aaa6b2c" });

            migrationBuilder.UpdateData(
                table: "PhotosCauses",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "~/images/marathon-cheering-e1490361550179-1024x573.jpg");

            migrationBuilder.UpdateData(
                table: "PhotosCauses",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "~/images/download.jpg");

            migrationBuilder.UpdateData(
                table: "PhotosCauses",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "~/images/download (2).jpg");

            migrationBuilder.UpdateData(
                table: "PhotosCauses",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "~/images/download (1).jpg");

            migrationBuilder.UpdateData(
                table: "PhotosCauses",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "~/images/volunteer-opportunities-ideas-article-1200x800.jpg");

            migrationBuilder.UpdateData(
                table: "PhotosOrganizations",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "~/images/Home+page+icons+(2).jpg");
        }
    }
}
