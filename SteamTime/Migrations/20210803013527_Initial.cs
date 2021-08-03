using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SteamTime.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SteamGame",
                columns: table => new
                {
                    AppId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SteamId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PlayTime = table.Column<int>(nullable: false),
                    PlayTimeTwoWeeks = table.Column<int>(nullable: false),
                    HashImgLogo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SteamGame", x => x.AppId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SteamGame");
        }
    }
}
