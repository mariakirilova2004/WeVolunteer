using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeVolunteer.Infrastructure.Migrations
{
    public partial class AddedCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Permaculture Projects, Farming, Ecovillages and Environmental Conservation", "Environmental Work" },
                    { 2, "Animal Farms, Wildlife Conservation, Animal Rescue and Animal Care", "Animals" },
                    { 3, "Children and Youth NGOs, Education & Teaching, Community Development, Women’s Empowerment", "Social Impact" },
                    { 4, "Health Care, Holistic Centers", "Health Care" },
                    { 5, "Hostel/Guest House Administration, Digital Marketing, SEO and Web Development", "Tourism" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
