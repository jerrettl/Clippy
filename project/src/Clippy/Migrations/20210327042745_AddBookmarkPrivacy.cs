using Microsoft.EntityFrameworkCore.Migrations;

namespace Clippy.Migrations
{
    public partial class AddBookmarkPrivacy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Bookmarks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsPublic",
                value: true);

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsPublic",
                value: true);

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsPublic",
                value: true);

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsPublic",
                value: true);

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsPublic",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Bookmarks");
        }
    }
}
