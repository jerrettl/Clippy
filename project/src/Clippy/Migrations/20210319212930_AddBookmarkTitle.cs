using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clippy.Migrations
{
    public partial class AddBookmarkTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Bookmarks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 21, 29, 29, 660, DateTimeKind.Utc).AddTicks(7342));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 21, 29, 29, 660, DateTimeKind.Utc).AddTicks(7342));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 21, 29, 29, 660, DateTimeKind.Utc).AddTicks(7342));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 21, 29, 29, 660, DateTimeKind.Utc).AddTicks(7342));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 21, 29, 29, 660, DateTimeKind.Utc).AddTicks(7342));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 21, 29, 29, 657, DateTimeKind.Utc).AddTicks(7778));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 21, 29, 29, 657, DateTimeKind.Utc).AddTicks(7778));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 21, 29, 29, 657, DateTimeKind.Utc).AddTicks(7778));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 21, 29, 29, 657, DateTimeKind.Utc).AddTicks(7778));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 21, 29, 29, 657, DateTimeKind.Utc).AddTicks(7778));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 21, 29, 29, 657, DateTimeKind.Utc).AddTicks(7778));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 21, 29, 29, 659, DateTimeKind.Utc).AddTicks(8764));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Bookmarks");

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
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 8, 19, 5, 173, DateTimeKind.Utc).AddTicks(644));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 8, 19, 5, 173, DateTimeKind.Utc).AddTicks(644));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 8, 19, 5, 173, DateTimeKind.Utc).AddTicks(644));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 8, 19, 5, 173, DateTimeKind.Utc).AddTicks(644));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 8, 19, 5, 173, DateTimeKind.Utc).AddTicks(644));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 8, 19, 5, 173, DateTimeKind.Utc).AddTicks(644));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 19, 8, 19, 5, 174, DateTimeKind.Utc).AddTicks(4429));
        }
    }
}
