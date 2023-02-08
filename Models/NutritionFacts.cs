using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace Fridgeopolis.Models
{
    public class NutritionFacts
    {
        [Key]
        [Column("nutrition_id")]
        public int NutritionId { get; set; }
        [Column("food_name")]
        [DisplayName("Name")]
        public string FoodName { get; set; }
        [Column("calories")]
        [DisplayName("Calories")]
        public int CaloriesPerServing { get; set; }
        [Column("carbohydrates")]
        [DisplayName("Carbohydrates")]
        public int CarbohydratesPerServing { get; set; }
        [Column("protein")]
        [DisplayName("Protein")]
        public int ProteinPerServing { get; set; }
        [Column("fat")]
        [DisplayName("Fat")]
        public int FatPerServing { get; set; }
        [Column("phosphorus")]
        [DisplayName("Phosphorus")]
        public int PhosphorusPerServing { get; set; }
        [Column("potassium")]
        [DisplayName("Potassium")]
        public int PotassiumPerServing { get; set; }
        [Column("sodium")]
        [DisplayName("Sodium")]
        public int SodiumPerServing { get; set; }
        [Column("servings")]
        [DisplayName("Servings")]
        public double Servings { get; set; }
        [Column("date")]
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
