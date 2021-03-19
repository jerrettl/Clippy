using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clippy.Migrations
{
    public partial class UseImageURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 8, 19, 5, 174, DateTimeKind.Utc).AddTicks(9700));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 8, 19, 5, 174, DateTimeKind.Utc).AddTicks(9700));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 8, 19, 5, 174, DateTimeKind.Utc).AddTicks(9700));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 8, 19, 5, 174, DateTimeKind.Utc).AddTicks(9700));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 8, 19, 5, 174, DateTimeKind.Utc).AddTicks(9700));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 3, 19, 8, 19, 5, 173, DateTimeKind.Utc).AddTicks(644), "{\"Title\":\"National Geographic\",\"MediaType\":\"text/html\",\"ImageURL\":\"natgeo.jpg\",\"Description\":\"Explore the world\\u0027s beauty.\"}" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 3, 19, 8, 19, 5, 173, DateTimeKind.Utc).AddTicks(644), "{\"Title\":\"Yellowstone National Park\",\"MediaType\":\"text/html\",\"ImageURL\":\"yellowstone.jpg\",\"Description\":\"Escape to a winter wonderland.\"}" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 3, 19, 8, 19, 5, 173, DateTimeKind.Utc).AddTicks(644), "{\"Title\":\"Food Network\",\"MediaType\":\"text/html\",\"ImageURL\":\"foodnetwork.jpg\",\"Description\":\"Entice your taste buds.\"}" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 3, 19, 8, 19, 5, 173, DateTimeKind.Utc).AddTicks(644), "{\"Title\":\"Love and Lemons\",\"MediaType\":\"text/html\",\"ImageURL\":\"lovelemons.jpg\",\"Description\":\"Detoxify yourself each day.\"}" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 3, 19, 8, 19, 5, 173, DateTimeKind.Utc).AddTicks(644), "{\"Title\":\"Appalachian Trail Conservancy\",\"MediaType\":\"text/html\",\"ImageURL\":\"appalachiantrail.jpg\",\"Description\":\"Escape the city lights.\"}" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 3, 19, 8, 19, 5, 173, DateTimeKind.Utc).AddTicks(644), "{\"Title\":\"SpaceX\",\"MediaType\":\"text/html\",\"ImageURL\":\"spacex.jpg\",\"Description\":\"Experience space travel.\"}" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 8, 19, 5, 174, DateTimeKind.Utc).AddTicks(4429));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 11, 17, 24, 36, 569, DateTimeKind.Utc).AddTicks(8890));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 3, 11, 17, 24, 36, 569, DateTimeKind.Utc).AddTicks(8890));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 3, 11, 17, 24, 36, 569, DateTimeKind.Utc).AddTicks(8890));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 3, 11, 17, 24, 36, 569, DateTimeKind.Utc).AddTicks(8890));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 3, 11, 17, 24, 36, 569, DateTimeKind.Utc).AddTicks(8890));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 3, 11, 17, 24, 36, 567, DateTimeKind.Utc).AddTicks(3470), "{\"Title\":\"National Geographic\",\"MediaType\":\"text/html\",\"Image\":\"https://api.clippy.fun/images/resources/natgeo.jpg\",\"Description\":\"Explore the world\\u0027s beauty.\"}" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 3, 11, 17, 24, 36, 567, DateTimeKind.Utc).AddTicks(3470), "{\"Title\":\"Yellowstone National Park\",\"MediaType\":\"text/html\",\"Image\":\"https://api.clippy.fun/images/resources/yellowstone.jpg\",\"Description\":\"Escape to a winter wonderland.\"}" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 3, 11, 17, 24, 36, 567, DateTimeKind.Utc).AddTicks(3470), "{\"Title\":\"Food Network\",\"MediaType\":\"text/html\",\"Image\":\"https://api.clippy.fun/images/resources/foodnetwork.jpg\",\"Description\":\"Entice your taste buds.\"}" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 3, 11, 17, 24, 36, 567, DateTimeKind.Utc).AddTicks(3470), "{\"Title\":\"Love and Lemons\",\"MediaType\":\"text/html\",\"Image\":\"https://api.clippy.fun/images/resources/lovelemons.jpg\",\"Description\":\"Detoxify yourself each day.\"}" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 3, 11, 17, 24, 36, 567, DateTimeKind.Utc).AddTicks(3470), "{\"Title\":\"Appalachian Trail Conservancy\",\"MediaType\":\"text/html\",\"Image\":\"https://api.clippy.fun/images/resources/appalachiantrail.jpg\",\"Description\":\"Escape the city lights.\"}" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreateDate", "Metadata" },
                values: new object[] { new DateTime(2021, 3, 11, 17, 24, 36, 567, DateTimeKind.Utc).AddTicks(3470), "{\"Title\":\"SpaceX\",\"MediaType\":\"text/html\",\"Image\":\"https://api.clippy.fun/images/resources/spacex.jpg\",\"Description\":\"Experience space travel.\"}" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 11, 17, 24, 36, 569, DateTimeKind.Utc).AddTicks(1940));
        }
    }
}
