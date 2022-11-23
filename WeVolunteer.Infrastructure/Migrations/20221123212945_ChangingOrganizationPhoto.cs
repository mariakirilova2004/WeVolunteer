using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeVolunteer.Infrastructure.Migrations
{
    public partial class ChangingOrganizationPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotosOrganizations_AspNetUsers_UserId",
                table: "PhotosOrganizations");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotosOrganizations_Organizations_OrganizationId",
                table: "PhotosOrganizations");

            migrationBuilder.DropIndex(
                name: "IX_PhotosOrganizations_UserId",
                table: "PhotosOrganizations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PhotosOrganizations");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationId",
                table: "PhotosOrganizations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Organizations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97bbdf24-befc-496f-bfc6-de4c6c380802", "AQAAAAEAACcQAAAAEG1N1uT1FGcy3Dy/JhT58vZsCuTDPoswB1Cs0R5ZE5enR+NKUi4lAsWIXVimU8/pwg==", "a8b952b6-12ed-4c13-9943-2f008671c3b5" });

            migrationBuilder.UpdateData(
                table: "PhotosOrganizations",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrganizationId",
                value: 1);

            migrationBuilder.InsertData(
                table: "PhotosOrganizations",
                columns: new[] { "Id", "ImageUrl", "OrganizationId" },
                values: new object[] { 2, "~/images/Organization2.jpg", 8 });

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_UserId",
                table: "Organizations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_AspNetUsers_UserId",
                table: "Organizations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotosOrganizations_Organizations_OrganizationId",
                table: "PhotosOrganizations",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_AspNetUsers_UserId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotosOrganizations_Organizations_OrganizationId",
                table: "PhotosOrganizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_UserId",
                table: "Organizations");

            migrationBuilder.DeleteData(
                table: "PhotosOrganizations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationId",
                table: "PhotosOrganizations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PhotosOrganizations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4e40bcb-e9d0-4ab4-a3dd-fafbbf67c11f", "AQAAAAEAACcQAAAAEK6N+rFxr5yCDNBEB8p8fYAMHABSx5MKpqPA/7c/JHnf0FXGpwDwi7rzZn2sNYA0Xg==", "688031f0-9dfe-4900-a7e1-f0e552a2d6ba" });

            migrationBuilder.UpdateData(
                table: "PhotosOrganizations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OrganizationId", "UserId" },
                values: new object[] { null, "deal12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.CreateIndex(
                name: "IX_PhotosOrganizations_UserId",
                table: "PhotosOrganizations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotosOrganizations_AspNetUsers_UserId",
                table: "PhotosOrganizations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotosOrganizations_Organizations_OrganizationId",
                table: "PhotosOrganizations",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }
    }
}
