using Microsoft.EntityFrameworkCore.Migrations;

namespace Clippy.Migrations
{
    public partial class UpdateSeedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvatarUrl", "Bio" },
                values: new object[] { "/images/resources/rando.jpg", "Our moon is so useless and pathetic compared to all of the cool moons out there in the solar system. While so much other moons have all these cool features, all our Moon did was hit us, and then get a free ride orbiting us for a few billion years." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvatarUrl", "Bio" },
                values: new object[] { null, null });
        }
    }
}
