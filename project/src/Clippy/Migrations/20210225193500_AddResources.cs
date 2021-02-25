using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clippy.Migrations
{
    public partial class AddResources : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Location = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    Metadata = table.Column<string>(type: "varchar", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreateDate", "Location", "Metadata" },
                values: new object[] { 1, new DateTime(2021, 2, 25, 19, 34, 59, 659, DateTimeKind.Utc).AddTicks(1850), "https://www.nationalgeographic.com", "{\"Title\":\"National Geographic\",\"MediaType\":\"text/html\"}" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreateDate", "Location", "Metadata" },
                values: new object[] { 2, new DateTime(2021, 2, 25, 19, 34, 59, 659, DateTimeKind.Utc).AddTicks(1850), "https://www.nps.gov/yell/index.htm", "{\"Title\":\"Yellowstone National Park\",\"MediaType\":\"text/html\"}" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreateDate", "Location", "Metadata" },
                values: new object[] { 3, new DateTime(2021, 2, 25, 19, 34, 59, 659, DateTimeKind.Utc).AddTicks(1850), "https://www.foodnetwork.com", "{\"Title\":\"Food Network\",\"MediaType\":\"text/html\"}" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreateDate", "Location", "Metadata" },
                values: new object[] { 4, new DateTime(2021, 2, 25, 19, 34, 59, 659, DateTimeKind.Utc).AddTicks(1850), "https://www.loveandlemons.com", "{\"Title\":\"Love and Lemons\",\"MediaType\":\"text/html\"}" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreateDate", "Location", "Metadata" },
                values: new object[] { 5, new DateTime(2021, 2, 25, 19, 34, 59, 659, DateTimeKind.Utc).AddTicks(1850), "https://appalachiantrail.org", "{\"Title\":\"Appalachian Trail Conservancy\",\"MediaType\":\"text/html\"}" });

            migrationBuilder.CreateIndex(
                name: "IX_Resources_Location",
                table: "Resources",
                column: "Location",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resources");
        }
    }
}
