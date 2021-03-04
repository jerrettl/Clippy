using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clippy.Migrations
{
    public partial class AddUserAndBookmarkSeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 4, 19, 51, 25, 87, DateTimeKind.Utc).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 3, 4, 19, 51, 25, 87, DateTimeKind.Utc).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 3, 4, 19, 51, 25, 87, DateTimeKind.Utc).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 3, 4, 19, 51, 25, 87, DateTimeKind.Utc).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 3, 4, 19, 51, 25, 87, DateTimeKind.Utc).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2021, 3, 4, 19, 51, 25, 87, DateTimeKind.Utc).AddTicks(6540));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "Name", "Username" },
                values: new object[] { 1, new DateTime(2021, 3, 4, 19, 51, 25, 89, DateTimeKind.Utc).AddTicks(2070), "Clippy5 Team", "Clippy5" });

            migrationBuilder.InsertData(
                table: "Bookmarks",
                columns: new[] { "Id", "CreateDate", "ResourceId", "UserId" },
                values: new object[] { 1, new DateTime(2021, 3, 4, 19, 51, 25, 89, DateTimeKind.Utc).AddTicks(5720), 2, 1 });

            migrationBuilder.InsertData(
                table: "Bookmarks",
                columns: new[] { "Id", "CreateDate", "ResourceId", "UserId" },
                values: new object[] { 2, new DateTime(2021, 3, 4, 19, 51, 25, 89, DateTimeKind.Utc).AddTicks(5720), 3, 1 });

            migrationBuilder.InsertData(
                table: "Bookmarks",
                columns: new[] { "Id", "CreateDate", "ResourceId", "UserId" },
                values: new object[] { 3, new DateTime(2021, 3, 4, 19, 51, 25, 89, DateTimeKind.Utc).AddTicks(5720), 4, 1 });

            migrationBuilder.InsertData(
                table: "Bookmarks",
                columns: new[] { "Id", "CreateDate", "ResourceId", "UserId" },
                values: new object[] { 4, new DateTime(2021, 3, 4, 19, 51, 25, 89, DateTimeKind.Utc).AddTicks(5720), 5, 1 });

            migrationBuilder.InsertData(
                table: "Bookmarks",
                columns: new[] { "Id", "CreateDate", "ResourceId", "UserId" },
                values: new object[] { 5, new DateTime(2021, 3, 4, 19, 51, 25, 89, DateTimeKind.Utc).AddTicks(5720), 6, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 4, 19, 18, 15, 63, DateTimeKind.Utc).AddTicks(950));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 3, 4, 19, 18, 15, 63, DateTimeKind.Utc).AddTicks(950));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 3, 4, 19, 18, 15, 63, DateTimeKind.Utc).AddTicks(950));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 3, 4, 19, 18, 15, 63, DateTimeKind.Utc).AddTicks(950));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 3, 4, 19, 18, 15, 63, DateTimeKind.Utc).AddTicks(950));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2021, 3, 4, 19, 18, 15, 63, DateTimeKind.Utc).AddTicks(950));
        }
    }
}
