using Microsoft.EntityFrameworkCore.Migrations;

namespace SteamTime.Migrations
{
    public partial class BooleanPlayedLast2Weeks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayTimeTwoWeeks",
                table: "SteamGame");

            migrationBuilder.AddColumn<bool>(
                name: "PlayedInLastTwoWeeks",
                table: "SteamGame",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayedInLastTwoWeeks",
                table: "SteamGame");

            migrationBuilder.AddColumn<int>(
                name: "PlayTimeTwoWeeks",
                table: "SteamGame",
                nullable: false,
                defaultValue: 0);
        }
    }
}
