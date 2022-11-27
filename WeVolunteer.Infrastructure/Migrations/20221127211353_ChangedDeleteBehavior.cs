using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeVolunteer.Infrastructure.Migrations
{
    public partial class ChangedDeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Causes_Categories_CategoryId",
                table: "Causes");

            migrationBuilder.DropForeignKey(
                name: "FK_Causes_Organizations_OrganizationId",
                table: "Causes");

            migrationBuilder.AddForeignKey(
                name: "FK_Causes_Categories_CategoryId",
                table: "Causes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Causes_Organizations_OrganizationId",
                table: "Causes",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Causes_Categories_CategoryId",
                table: "Causes");

            migrationBuilder.DropForeignKey(
                name: "FK_Causes_Organizations_OrganizationId",
                table: "Causes");

            migrationBuilder.AddForeignKey(
                name: "FK_Causes_Categories_CategoryId",
                table: "Causes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Causes_Organizations_OrganizationId",
                table: "Causes",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
