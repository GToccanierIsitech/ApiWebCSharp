using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToccanierGregoryApiPoker.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    startdate = table.Column<DateTime>(name: "start_date", type: "datetime(6)", nullable: true),
                    enddate = table.Column<DateTime>(name: "end_date", type: "datetime(6)", nullable: true),
                    pot = table.Column<int>(type: "int", nullable: true),
                    buyin = table.Column<int>(name: "buy_in", type: "int", nullable: true),
                    maxplayers = table.Column<int>(name: "max_players", type: "int", nullable: true),
                    nbturn = table.Column<int>(name: "nb_turn", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "Varchar(30)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "Varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    money = table.Column<int>(type: "int", nullable: true),
                    birthdate = table.Column<DateTime>(name: "birth_date", type: "datetime(6)", nullable: true),
                    nbgames = table.Column<int>(name: "nb_games", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    money = table.Column<int>(type: "int", nullable: true),
                    gameid = table.Column<int>(name: "game_id", type: "int", nullable: true),
                    userid = table.Column<int>(name: "user_id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.id);
                    table.ForeignKey(
                        name: "FK_Players_Games_game_id",
                        column: x => x.gameid,
                        principalTable: "Games",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Players_Users_user_id",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "ENUM(\"As\", \"Deux\", \"Trois\", \"Quatre\", \"Cinq\", \"Six\", \"Sept\", \"Huit\", \"Neuf\", \"Dix\", \"Valet\", \"Dame\", \"Roi\")", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    couleur = table.Column<string>(type: "ENUM(\"Trèfle\", \"Carreau\", \"Coeur\", \"Pique\")", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    symbole = table.Column<string>(type: "ENUM(\"A\", \"2\", \"3\", \"4\", \"5\", \"6\", \"7\", \"8\", \"9\", \"10\", \"J\", \"Q\", \"K\")", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    values = table.Column<int>(type: "int", nullable: true),
                    playerid = table.Column<int>(name: "player_id", type: "int", nullable: true),
                    gameid = table.Column<int>(name: "game_id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cards_Games_game_id",
                        column: x => x.gameid,
                        principalTable: "Games",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Cards_Players_player_id",
                        column: x => x.playerid,
                        principalTable: "Players",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_game_id",
                table: "Cards",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_player_id",
                table: "Cards",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "IX_Players_game_id",
                table: "Players",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "IX_Players_user_id",
                table: "Players",
                column: "user_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
