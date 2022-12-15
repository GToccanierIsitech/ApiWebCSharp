using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToccanierGregoryApiPoker.Migrations
{
    /// <inheritdoc />
    public partial class AddRequiredCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "values",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "symbole",
                keyValue: null,
                column: "symbole",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "symbole",
                table: "Cards",
                type: "ENUM(\"A\", \"2\", \"3\", \"4\", \"5\", \"6\", \"7\", \"8\", \"9\", \"10\", \"J\", \"Q\", \"K\")",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "ENUM(\"A\", \"2\", \"3\", \"4\", \"5\", \"6\", \"7\", \"8\", \"9\", \"10\", \"J\", \"Q\", \"K\")",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "name",
                keyValue: null,
                column: "name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Cards",
                type: "ENUM(\"As\", \"Deux\", \"Trois\", \"Quatre\", \"Cinq\", \"Six\", \"Sept\", \"Huit\", \"Neuf\", \"Dix\", \"Valet\", \"Dame\", \"Roi\")",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "ENUM(\"As\", \"Deux\", \"Trois\", \"Quatre\", \"Cinq\", \"Six\", \"Sept\", \"Huit\", \"Neuf\", \"Dix\", \"Valet\", \"Dame\", \"Roi\")",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "couleur",
                keyValue: null,
                column: "couleur",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "couleur",
                table: "Cards",
                type: "ENUM(\"Trèfle\", \"Carreau\", \"Coeur\", \"Pique\")",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "ENUM(\"Trèfle\", \"Carreau\", \"Coeur\", \"Pique\")",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "values",
                table: "Cards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "symbole",
                table: "Cards",
                type: "ENUM(\"A\", \"2\", \"3\", \"4\", \"5\", \"6\", \"7\", \"8\", \"9\", \"10\", \"J\", \"Q\", \"K\")",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ENUM(\"A\", \"2\", \"3\", \"4\", \"5\", \"6\", \"7\", \"8\", \"9\", \"10\", \"J\", \"Q\", \"K\")")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Cards",
                type: "ENUM(\"As\", \"Deux\", \"Trois\", \"Quatre\", \"Cinq\", \"Six\", \"Sept\", \"Huit\", \"Neuf\", \"Dix\", \"Valet\", \"Dame\", \"Roi\")",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ENUM(\"As\", \"Deux\", \"Trois\", \"Quatre\", \"Cinq\", \"Six\", \"Sept\", \"Huit\", \"Neuf\", \"Dix\", \"Valet\", \"Dame\", \"Roi\")")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "couleur",
                table: "Cards",
                type: "ENUM(\"Trèfle\", \"Carreau\", \"Coeur\", \"Pique\")",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ENUM(\"Trèfle\", \"Carreau\", \"Coeur\", \"Pique\")")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
