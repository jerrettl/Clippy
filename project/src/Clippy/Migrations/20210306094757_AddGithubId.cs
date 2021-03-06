using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clippy.Migrations
{
    public partial class AddGithubId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GithubId",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 6, 9, 47, 57, 432, DateTimeKind.Utc).AddTicks(1313));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 3, 6, 9, 47, 57, 432, DateTimeKind.Utc).AddTicks(1313));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 3, 6, 9, 47, 57, 432, DateTimeKind.Utc).AddTicks(1313));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 3, 6, 9, 47, 57, 432, DateTimeKind.Utc).AddTicks(1313));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 3, 6, 9, 47, 57, 432, DateTimeKind.Utc).AddTicks(1313));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 6, 9, 47, 57, 430, DateTimeKind.Utc).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 3, 6, 9, 47, 57, 430, DateTimeKind.Utc).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 3, 6, 9, 47, 57, 430, DateTimeKind.Utc).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 3, 6, 9, 47, 57, 430, DateTimeKind.Utc).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 3, 6, 9, 47, 57, 430, DateTimeKind.Utc).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2021, 3, 6, 9, 47, 57, 430, DateTimeKind.Utc).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 6, 9, 47, 57, 431, DateTimeKind.Utc).AddTicks(5833));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GithubId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 4, 19, 51, 25, 89, DateTimeKind.Utc).AddTicks(5720));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 3, 4, 19, 51, 25, 89, DateTimeKind.Utc).AddTicks(5720));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 3, 4, 19, 51, 25, 89, DateTimeKind.Utc).AddTicks(5720));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 3, 4, 19, 51, 25, 89, DateTimeKind.Utc).AddTicks(5720));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 3, 4, 19, 51, 25, 89, DateTimeKind.Utc).AddTicks(5720));

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 4, 19, 51, 25, 89, DateTimeKind.Utc).AddTicks(2070));
        }
    }
}
