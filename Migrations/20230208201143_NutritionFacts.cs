using Microsoft.EntityFrameworkCore.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fridgeopolis.Migrations
{
    /// <inheritdoc />
    public partial class NutritionFacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NutritionData",
                columns: table => new
                {
                    nutritionid = table.Column<int>(name: "nutrition_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    foodname = table.Column<string>(name: "food_name", type: "nvarchar(max)", nullable: false),
                    calories = table.Column<int>(type: "int", nullable: false),
                    carbohydrates = table.Column<int>(type: "int", nullable: false),
                    protein = table.Column<int>(type: "int", nullable: false),
                    fat = table.Column<int>(type: "int", nullable: false),
                    phosphorus = table.Column<int>(type: "int", nullable: false),
                    potassium = table.Column<int>(type: "int", nullable: false),
                    sodium = table.Column<int>(type: "int", nullable: false),
                    servings = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionData", x => x.nutritionid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NutritionData");
        }
    }
}
