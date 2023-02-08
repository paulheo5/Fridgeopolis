using System.Security.Permissions;

namespace Fridgeopolis.Models
{
    public class NutritionFacts
    {
        public int NutritionId { get; set; }
        public string FoodName { get; set; }
        public int Calories { get; set; }
        public int Carbohydrates { get; set; }
        public int Protein { get; set; }
        public int Fat { get; set; }
        public int Phosphorus { get; set; }
        public int Potassium { get; set; }
        public int Sodium { get; set; }
    }
}
