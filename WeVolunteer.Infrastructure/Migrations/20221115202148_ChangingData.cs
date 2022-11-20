using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeVolunteer.Infrastructure.Migrations
{
    public partial class ChangingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a0b6241-900b-4a29-b45b-0fe825872697", "AQAAAAEAACcQAAAAELMCGqDnIn+1QqwwUS/HD2a7CciX7hzMSuzOsSTWAA0AwMgKSt1jvdtLZcoM915FWg==", "8f081b39-2057-4a6a-aee3-e24531f13cc5" });

            migrationBuilder.UpdateData(
                table: "PhotosCauses",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "C:\\Maria\\SoftUni Programming\\Advanced\\C# WEB\\WeVolunteer\\WeVolunteer.Core\\Resources\\Images\\marathon-cheering-e1490361550179-1024x573.jpg");

            migrationBuilder.UpdateData(
                table: "PhotosCauses",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "C:\\Maria\\SoftUni Programming\\Advanced\\C# WEB\\WeVolunteer\\WeVolunteer.Core\\Resources\\Images\\download.jpg");

            migrationBuilder.UpdateData(
                table: "PhotosCauses",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "C:\\Maria\\SoftUni Programming\\Advanced\\C# WEB\\WeVolunteer\\WeVolunteer.Core\\Resources\\Images\\download (2).jpg");

            migrationBuilder.UpdateData(
                table: "PhotosCauses",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "C:\\Maria\\SoftUni Programming\\Advanced\\C# WEB\\WeVolunteer\\WeVolunteer.Core\\Resources\\Images\\download (1).jpg");

            migrationBuilder.UpdateData(
                table: "PhotosCauses",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "C:\\Maria\\SoftUni Programming\\Advanced\\C# WEB\\WeVolunteer\\WeVolunteer.Core\\Resources\\Images\\volunteer-opportunities-ideas-article-1200x800.jpg");

            migrationBuilder.UpdateData(
                table: "PhotosOrganizations",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "C:\\Maria\\SoftUni Programming\\Advanced\\C# WEB\\WeVolunteer\\WeVolunteer.Core\\Resources\\Images\\Home+page+icons+(2).jpg");
        }
    }
}
