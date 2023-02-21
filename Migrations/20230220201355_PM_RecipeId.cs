using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Renipe.Migrations
{
    /// <inheritdoc />
    public partial class PMRecipeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Datum");

            migrationBuilder.DropTable(
                name: "RecipeData");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "PropertyRecipe",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "PropertyRecipe");

            migrationBuilder.CreateTable(
                name: "RecipeData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReadyInMinutes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeData", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Datum",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeDataID = table.Column<int>(type: "int", nullable: true),
                    step = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datum", x => x.id);
                    table.ForeignKey(
                        name: "FK_Datum_RecipeData_RecipeDataID",
                        column: x => x.RecipeDataID,
                        principalTable: "RecipeData",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Datum_RecipeDataID",
                table: "Datum",
                column: "RecipeDataID");
        }
    }
}
