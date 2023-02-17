using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Renipe.Migrations
{
    /// <inheritdoc />
    public partial class MealServingSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "serving_size",
                table: "NutritionData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "serving_size_unit",
                table: "NutritionData",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "serving_size",
                table: "NutritionData");

            migrationBuilder.DropColumn(
                name: "serving_size_unit",
                table: "NutritionData");
        }
    }
}
