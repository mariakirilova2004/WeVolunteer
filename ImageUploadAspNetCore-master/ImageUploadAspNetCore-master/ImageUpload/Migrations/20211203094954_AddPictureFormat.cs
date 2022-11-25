using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageUpload.Migrations
{
    public partial class AddPictureFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureFormat",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureFormat",
                table: "Users");
        }
    }
}
