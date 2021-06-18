using Microsoft.EntityFrameworkCore.Migrations;

namespace Musicplayer.Migrations
{
    public partial class SeedSongTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Language", "Title" },
                values: new object[] { 1, "English", "sanjay" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Language", "Title" },
                values: new object[] { 2, "Enish", "sany" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
