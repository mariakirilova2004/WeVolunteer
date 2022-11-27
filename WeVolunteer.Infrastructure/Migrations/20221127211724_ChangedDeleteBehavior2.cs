using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeVolunteer.Infrastructure.Migrations
{
    public partial class ChangedDeleteBehavior2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Causes_Organizations_OrganizationId",
                table: "Causes");

            migrationBuilder.AddForeignKey(
                name: "FK_Causes_Organizations_OrganizationId",
                table: "Causes",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Causes_Organizations_OrganizationId",
                table: "Causes");

            migrationBuilder.AddForeignKey(
                name: "FK_Causes_Organizations_OrganizationId",
                table: "Causes",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
