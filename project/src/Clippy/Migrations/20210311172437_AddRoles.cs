using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clippy.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                column: "CreateDate",
                value: new DateTime(2021, 3, 11, 17, 24, 36, 567, DateTimeKind.Utc).AddTicks(3470));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 3, 11, 17, 24, 36, 567, DateTimeKind.Utc).AddTicks(3470));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 3, 11, 17, 24, 36, 567, DateTimeKind.Utc).AddTicks(3470));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 3, 11, 17, 24, 36, 567, DateTimeKind.Utc).AddTicks(3470));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 3, 11, 17, 24, 36, 567, DateTimeKind.Utc).AddTicks(3470));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2021, 3, 11, 17, 24, 36, 567, DateTimeKind.Utc).AddTicks(3470));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 11, 17, 24, 36, 569, DateTimeKind.Utc).AddTicks(1940));

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 10, 16, 24, 39, 105, DateTimeKind.Utc).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 3, 10, 16, 24, 39, 105, DateTimeKind.Utc).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 3, 10, 16, 24, 39, 105, DateTimeKind.Utc).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 3, 10, 16, 24, 39, 105, DateTimeKind.Utc).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 3, 10, 16, 24, 39, 105, DateTimeKind.Utc).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 10, 16, 24, 39, 102, DateTimeKind.Utc).AddTicks(9970));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 3, 10, 16, 24, 39, 102, DateTimeKind.Utc).AddTicks(9970));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 3, 10, 16, 24, 39, 102, DateTimeKind.Utc).AddTicks(9970));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 3, 10, 16, 24, 39, 102, DateTimeKind.Utc).AddTicks(9970));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 3, 10, 16, 24, 39, 102, DateTimeKind.Utc).AddTicks(9970));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2021, 3, 10, 16, 24, 39, 102, DateTimeKind.Utc).AddTicks(9970));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 3, 10, 16, 24, 39, 104, DateTimeKind.Utc).AddTicks(6130));
        }
    }
}
