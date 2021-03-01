using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clippy.Migrations
{
    public partial class UpdateResourcesSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 2, 27, 16, 29, 12, 181, DateTimeKind.Utc).AddTicks(3750), "{\"Title\":\"National Geographic\",\"MediaType\":\"text/html\",\"Image\":\"https://api.clippy.fun/images/resources/natgeo.jpg\",\"Description\":\"Explore the world\\u0027s beauty.\"}" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 2, 27, 16, 29, 12, 181, DateTimeKind.Utc).AddTicks(3750), "{\"Title\":\"Yellowstone National Park\",\"MediaType\":\"text/html\",\"Image\":\"https://api.clippy.fun/images/resources/yellowstone.jpg\",\"Description\":\"Escape to a winter wonderland.\"}" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 2, 27, 16, 29, 12, 181, DateTimeKind.Utc).AddTicks(3750), "{\"Title\":\"Food Network\",\"MediaType\":\"text/html\",\"Image\":\"https://api.clippy.fun/images/resources/foodnetwork.jpg\",\"Description\":\"Entice your taste buds.\"}" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 2, 27, 16, 29, 12, 181, DateTimeKind.Utc).AddTicks(3750), "{\"Title\":\"Love and Lemons\",\"MediaType\":\"text/html\",\"Image\":\"https://api.clippy.fun/images/resources/lovelemons.jpg\",\"Description\":\"Detoxify yourself each day.\"}" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 2, 27, 16, 29, 12, 181, DateTimeKind.Utc).AddTicks(3750), "{\"Title\":\"Appalachian Trail Conservancy\",\"MediaType\":\"text/html\",\"Image\":\"https://api.clippy.fun/images/resources/appalachiantrail.jpg\",\"Description\":\"Escape the city lights.\"}" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreateDate", "Location", "Metadata" },
                values: new object[] { 6, new DateTime(2021, 2, 27, 16, 29, 12, 181, DateTimeKind.Utc).AddTicks(3750), "https://www.spacex.com", "{\"Title\":\"SpaceX\",\"MediaType\":\"text/html\",\"Image\":\"https://api.clippy.fun/images/resources/spacex.jpg\",\"Description\":\"Experience space travel.\"}" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 2, 25, 19, 34, 59, 659, DateTimeKind.Utc).AddTicks(1850), "{\"Title\":\"National Geographic\",\"MediaType\":\"text/html\"}" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 2, 25, 19, 34, 59, 659, DateTimeKind.Utc).AddTicks(1850), "{\"Title\":\"Yellowstone National Park\",\"MediaType\":\"text/html\"}" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 2, 25, 19, 34, 59, 659, DateTimeKind.Utc).AddTicks(1850), "{\"Title\":\"Food Network\",\"MediaType\":\"text/html\"}" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 2, 25, 19, 34, 59, 659, DateTimeKind.Utc).AddTicks(1850), "{\"Title\":\"Love and Lemons\",\"MediaType\":\"text/html\"}" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 2, 25, 19, 34, 59, 659, DateTimeKind.Utc).AddTicks(1850), "{\"Title\":\"Appalachian Trail Conservancy\",\"MediaType\":\"text/html\"}" });
        }
    }
}
