using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clippy.Migrations
{
    public partial class UpdateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ResourceId", "Title" },
                values: new object[] { new DateTime(2021, 3, 2, 14, 8, 6, 0, DateTimeKind.Utc), 1, "National Geographic" });

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "ResourceId", "Title" },
                values: new object[] { new DateTime(2021, 3, 2, 18, 21, 8, 0, DateTimeKind.Utc), 2, "Yellowstone National Park" });

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "ResourceId", "Title" },
                values: new object[] { new DateTime(2021, 3, 3, 17, 38, 42, 0, DateTimeKind.Utc), 3, "Food Network" });

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "ResourceId", "Title" },
                values: new object[] { new DateTime(2021, 3, 3, 23, 59, 0, 0, DateTimeKind.Utc), 4, "Love and Lemons" });

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateDate", "ResourceId", "Title" },
                values: new object[] { new DateTime(2021, 3, 4, 5, 12, 58, 0, DateTimeKind.Utc), 5, "Appalachian Trail Conservancy" });

            migrationBuilder.InsertData(
                table: "Bookmarks",
                columns: new[] { "Id", "CreateDate", "Description", "Favorited", "IsPublic", "ResourceId", "Title", "UserId" },
                values: new object[] { 6, new DateTime(2021, 3, 10, 9, 45, 32, 0, DateTimeKind.Utc), null, false, true, 6, "SpaceX", 1 });

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 1,
                column: "TagName",
                value: "Nature");

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 2,
                column: "TagName",
                value: "Adventure");

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookmarkId", "TagName" },
                values: new object[] { 2, "Park" });

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookmarkId", "TagName" },
                values: new object[] { 3, "Food" });

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BookmarkId", "TagName" },
                values: new object[] { 4, "Detox" });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "BookmarkId", "TagName" },
                values: new object[] { 6, 4, "Nutrition" });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "BookmarkId", "TagName" },
                values: new object[] { 7, 5, "Adventure" });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "BookmarkId", "TagName" },
                values: new object[] { 8, 5, "Hike" });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "BookmarkId", "TagName" },
                values: new object[] { 9, 6, "Space" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ResourceId", "Title" },
                values: new object[] { new DateTime(2021, 3, 2, 18, 21, 8, 0, DateTimeKind.Utc), 2, "Yellowstone National Park" });

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "ResourceId", "Title" },
                values: new object[] { new DateTime(2021, 3, 3, 17, 38, 42, 0, DateTimeKind.Utc), 3, "Food Network" });

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "ResourceId", "Title" },
                values: new object[] { new DateTime(2021, 3, 3, 23, 59, 0, 0, DateTimeKind.Utc), 4, "Love and Lemons" });

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "ResourceId", "Title" },
                values: new object[] { new DateTime(2021, 3, 4, 5, 12, 58, 0, DateTimeKind.Utc), 5, "Appalachian Trail Conservancy" });

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateDate", "ResourceId", "Title" },
                values: new object[] { new DateTime(2021, 3, 10, 9, 45, 32, 0, DateTimeKind.Utc), 6, "SpaceX" });

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 1,
                column: "TagName",
                value: "favorite");

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 2,
                column: "TagName",
                value: "favorite");

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookmarkId", "TagName" },
                values: new object[] { 3, "favorite" });

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookmarkId", "TagName" },
                values: new object[] { 4, "favorite" });

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BookmarkId", "TagName" },
                values: new object[] { 5, "favorite" });
        }
    }
}
