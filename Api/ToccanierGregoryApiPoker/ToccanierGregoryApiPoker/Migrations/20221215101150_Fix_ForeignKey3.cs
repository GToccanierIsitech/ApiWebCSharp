using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToccanierGregoryApiPoker.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKey3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Games_game_id",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Players_player_id",
                table: "Cards");

            migrationBuilder.AlterColumn<int>(
                name: "player_id",
                table: "Cards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "game_id",
                table: "Cards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Games_game_id",
                table: "Cards",
                column: "game_id",
                principalTable: "Games",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Players_player_id",
                table: "Cards",
                column: "player_id",
                principalTable: "Players",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Games_game_id",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Players_player_id",
                table: "Cards");

            migrationBuilder.AlterColumn<int>(
                name: "player_id",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "game_id",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Games_game_id",
                table: "Cards",
                column: "game_id",
                principalTable: "Games",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Players_player_id",
                table: "Cards",
                column: "player_id",
                principalTable: "Players",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
