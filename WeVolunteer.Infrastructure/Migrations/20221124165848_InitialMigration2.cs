using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeVolunteer.Infrastructure.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95a629b9-b0a5-465f-ace3-0a0db8b6fe63", "AQAAAAEAACcQAAAAEPqy1DRUtrNYeIPkxIok1r1ZkzNohn+zL5UH/2zj/fbFwBuy8ZYz0K146epo2rnBzQ==", "aa744c52-f407-4082-8a74-9108937247af" });

            migrationBuilder.InsertData(
                table: "PhotosOrganizations",
                columns: new[] { "Id", "ImageUrl", "OrganizationId" },
                values: new object[] { 2, "~/images/Organization2.jpg", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PhotosOrganizations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3410cbf-1957-4abc-a838-96204b3a6c7c", "AQAAAAEAACcQAAAAEJz904vWMqUsOilt32Enng15OCfsh+GZL2cwt3m4Jj2s/CgtMe2Q1HC6SvRlnHCMfA==", "a1d30260-c680-4bfe-b409-4ffdc939d5ca" });
        }
    }
}
