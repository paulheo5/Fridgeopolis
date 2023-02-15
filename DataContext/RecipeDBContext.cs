using Fridgeopolis.Models;
using Microsoft.EntityFrameworkCore;

namespace Fridgeopolis.DataContext
{
    public class RecipeDBContext : DbContext
    {
        public RecipeDBContext() { }
        public RecipeDBContext(DbContextOptions<RecipeDBContext> options) : base(options)
        {
        }
 
        public DbSet<PropertyModel> PropertyRecipe { get; set; }
        public DbSet<Meal> NutritionData { get; set; }

    }
}

