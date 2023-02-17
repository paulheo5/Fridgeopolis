using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Renipe.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReadyInMinutes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    step = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeDataID = table.Column<int>(type: "int", nullable: true)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Datum");

            migrationBuilder.DropTable(
                name: "RecipeData");
        }
    }
}
