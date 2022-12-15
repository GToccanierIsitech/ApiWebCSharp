using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToccanierGregoryApiPoker.Migrations
{
    /// <inheritdoc />
    public partial class Removenbturn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nb_turn",
                table: "Games");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "nb_turn",
                table: "Games",
                type: "int",
                nullable: true);
        }
    }
}
