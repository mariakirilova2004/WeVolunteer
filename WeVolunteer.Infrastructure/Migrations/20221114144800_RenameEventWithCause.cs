using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeVolunteer.Infrastructure.Migrations
{
    public partial class RenameEventWithCause : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Events_EventId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "PhotosEvents");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Categories",
                newName: "CauseId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_EventId",
                table: "Categories",
                newName: "IX_Categories_CauseId");

            migrationBuilder.CreateTable(
                name: "Causes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Place = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Causes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Causes_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhotosCauses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CauseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotosCauses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotosCauses_Causes_CauseId",
                        column: x => x.CauseId,
                        principalTable: "Causes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a0b6241-900b-4a29-b45b-0fe825872697", "AQAAAAEAACcQAAAAELMCGqDnIn+1QqwwUS/HD2a7CciX7hzMSuzOsSTWAA0AwMgKSt1jvdtLZcoM915FWg==", "8f081b39-2057-4a6a-aee3-e24531f13cc5" });

            migrationBuilder.InsertData(
                table: "Causes",
                columns: new[] { "Id", "Description", "Name", "OrganizationId", "Place", "Time" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Get in the network", 1, "Sofia, Bulgaria", new DateTime(2001, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Gift giving", 1, "Sofia, Bulgaria", new DateTime(2001, 2, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Elderly homes improvement", 1, "Sofia, Bulgaria", new DateTime(2001, 3, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Humans Best friends", 1, "Sofia, Bulgaria", new DateTime(2001, 4, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PhotosCauses",
                columns: new[] { "Id", "CauseId", "ImageUrl" },
                values: new object[,]
                {
                    { 1, 1, "C:\\Maria\\SoftUni Programming\\Advanced\\C# WEB\\WeVolunteer\\WeVolunteer.Core\\Resources\\Images\\marathon-cheering-e1490361550179-1024x573.jpg" },
                    { 2, 3, "C:\\Maria\\SoftUni Programming\\Advanced\\C# WEB\\WeVolunteer\\WeVolunteer.Core\\Resources\\Images\\download.jpg" },
                    { 3, 2, "C:\\Maria\\SoftUni Programming\\Advanced\\C# WEB\\WeVolunteer\\WeVolunteer.Core\\Resources\\Images\\download (2).jpg" },
                    { 4, 3, "C:\\Maria\\SoftUni Programming\\Advanced\\C# WEB\\WeVolunteer\\WeVolunteer.Core\\Resources\\Images\\download (1).jpg" },
                    { 5, 4, "C:\\Maria\\SoftUni Programming\\Advanced\\C# WEB\\WeVolunteer\\WeVolunteer.Core\\Resources\\Images\\volunteer-opportunities-ideas-article-1200x800.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Causes_OrganizationId",
                table: "Causes",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosCauses_CauseId",
                table: "PhotosCauses",
                column: "CauseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Causes_CauseId",
                table: "Categories",
                column: "CauseId",
                principalTable: "Causes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Causes_CauseId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "PhotosCauses");

            migrationBuilder.DropTable(
                name: "Causes");

            migrationBuilder.RenameColumn(
                name: "CauseId",
                table: "Categories",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CauseId",
                table: "Categories",
                newName: "IX_Categories_EventId");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Place = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhotosEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotosEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotosEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deal12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7933d930-4f18-4674-a5f4-018050283fc0", "AQAAAAEAACcQAAAAEByAkIAk5+InmQNo6CqkK426Wc2sf5uMO/4C/0s9+/Zwez6PK+jjXPKuCUGb7D9KLA==", "d72ea964-7509-4d5f-9091-33124883af2c" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "Name", "OrganizationId", "Place", "Time" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Get in the network", 1, "Sofia, Bulgaria", new DateTime(2001, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Gift giving", 1, "Sofia, Bulgaria", new DateTime(2001, 2, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Elderly homes improvement", 1, "Sofia, Bulgaria", new DateTime(2001, 3, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Humans Best friends", 1, "Sofia, Bulgaria", new DateTime(2001, 4, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PhotosEvents",
                columns: new[] { "Id", "EventId", "ImageUrl" },
                values: new object[,]
                {
                    { 1, 1, "C:\\Maria\\SoftUni Programming\\Advanced\\C# WEB\\WeVolunteer\\WeVolunteer.Core\\Resources\\Images\\marathon-cheering-e1490361550179-1024x573.jpg" },
                    { 2, 3, "C:\\Maria\\SoftUni Programming\\Advanced\\C# WEB\\WeVolunteer\\WeVolunteer.Core\\Resources\\Images\\download.jpg" },
                    { 3, 2, "C:\\Maria\\SoftUni Programming\\Advanced\\C# WEB\\WeVolunteer\\WeVolunteer.Core\\Resources\\Images\\download (2).jpg" },
                    { 4, 3, "C:\\Maria\\SoftUni Programming\\Advanced\\C# WEB\\WeVolunteer\\WeVolunteer.Core\\Resources\\Images\\download (1).jpg" },
                    { 5, 4, "C:\\Maria\\SoftUni Programming\\Advanced\\C# WEB\\WeVolunteer\\WeVolunteer.Core\\Resources\\Images\\volunteer-opportunities-ideas-article-1200x800.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizationId",
                table: "Events",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosEvents_EventId",
                table: "PhotosEvents",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Events_EventId",
                table: "Categories",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
