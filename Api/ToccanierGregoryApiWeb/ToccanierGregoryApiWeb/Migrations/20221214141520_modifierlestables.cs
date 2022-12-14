using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToccanierGregoryApiWeb.Migrations
{
    /// <inheritdoc />
    public partial class modifierlestables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Players",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Players",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "nbGames",
                table: "Players",
                newName: "nbr_games");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "Players",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "Players",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "nbr_games",
                table: "Players",
                newName: "nbGames");
        }
    }
}
