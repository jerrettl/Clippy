using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clippy.Migrations
{
    public partial class AddTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookmarkId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_Bookmarks_BookmarkId",
                        column: x => x.BookmarkId,
                        principalTable: "Bookmarks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 9, 16, 25, 14, 918, DateTimeKind.Utc).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 3, 9, 16, 25, 14, 918, DateTimeKind.Utc).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 3, 9, 16, 25, 14, 918, DateTimeKind.Utc).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 3, 9, 16, 25, 14, 918, DateTimeKind.Utc).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 3, 9, 16, 25, 14, 918, DateTimeKind.Utc).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 9, 16, 25, 14, 916, DateTimeKind.Utc).AddTicks(670));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 3, 9, 16, 25, 14, 916, DateTimeKind.Utc).AddTicks(670));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 3, 9, 16, 25, 14, 916, DateTimeKind.Utc).AddTicks(670));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 3, 9, 16, 25, 14, 916, DateTimeKind.Utc).AddTicks(670));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 3, 9, 16, 25, 14, 916, DateTimeKind.Utc).AddTicks(670));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2021, 3, 9, 16, 25, 14, 916, DateTimeKind.Utc).AddTicks(670));

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "BookmarkId", "TagName" },
                values: new object[] { 1, 1, "favorite" });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "BookmarkId", "TagName" },
                values: new object[] { 4, 4, "favorite" });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "BookmarkId", "TagName" },
                values: new object[] { 3, 3, "favorite" });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "BookmarkId", "TagName" },
                values: new object[] { 2, 2, "favorite" });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "BookmarkId", "TagName" },
                values: new object[] { 5, 5, "favorite" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 9, 16, 25, 14, 917, DateTimeKind.Utc).AddTicks(6040));

            migrationBuilder.CreateIndex(
                name: "IX_Tag_BookmarkId",
                table: "Tag",
                column: "BookmarkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tag");

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
    }
}
