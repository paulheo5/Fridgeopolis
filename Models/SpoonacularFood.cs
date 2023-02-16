using Microsoft.Identity.Client;

namespace Fridgeopolis.Models
{
    public class Bad
    {
        public string title { get; set; }
        public string amount { get; set; }
        public bool indented { get; set; }
        public double percentOfDailyNeeds { get; set; }
    }

    public class CaloricBreakdown
    {
        public double percentProtein { get; set; }
        public double percentFat { get; set; }
        public double percentCarbs { get; set; }
    }

    public class Flavonoid
    {
        public string name { get; set; }
        public double amount { get; set; }
        public string unit { get; set; }
    }

    public class Good
    {
        public string title { get; set; }
        public string amount { get; set; }
        public bool indented { get; set; }
        public double percentOfDailyNeeds { get; set; }
    }

    public class SPIngredient
    {
        public int id { get; set; }
        public string name { get; set; }
        public double amount { get; set; }
        public string unit { get; set; }
        public List<Nutrient> nutrients { get; set; }
    }

    public class Nutrient
    {
        public string name { get; set; }
        public double amount { get; set; }
        public string unit { get; set; }
        public double percentOfDailyNeeds { get; set; }
    }

    public class Property
    {
        public string name { get; set; }
        public double amount { get; set; }
        public string unit { get; set; }
    }
    public static class SPToMeal
    {
        public static NutritionFacts ToNutritionFacts(this SpoonacularFood food)
        {
            int calories = int.Parse(food.calories);
            int carbohydrates = int.Parse(food.carbs);
            int protein = int.Parse(food.protein);
            int fat = int.Parse(food.fat);
            int phosphorus = -1;
            int potassium = -1;
            int sodium = -1;
            string servingSize = "";
            string servingSizeUnit = "";

            //check for nutrients list and get renal nutrients from it
            if(food.nutrients != null)
            {
                phosphorus = (int?) Math.Round(food.nutrients.SingleOrDefault(n => n.name.ToLower() == "phosphorus").amount) ?? -1;
                potassium = (int?)Math.Round(food.nutrients.SingleOrDefault(n => n.name.ToLower() == "potassium").amount) ?? -1;
                sodium = (int?)Math.Round(food.nutrients.SingleOrDefault(n => n.name.ToLower() == "sodium").amount) ?? -1;
            }
            else
            {
                //check good list for nutrients if exists
                if(food.good != null)
                {
                    phosphorus = (int?)Math.Round(double.Parse(food.good.SingleOrDefault(n => n.title.ToLower() == "phosphorus").amount)) ?? -1;
                    potassium = (int?)Math.Round(double.Parse(food.good.SingleOrDefault(n => n.title.ToLower() == "potassium").amount)) ?? -1;
                    sodium = (int?)Math.Round(double.Parse(food.good.SingleOrDefault(n => n.title.ToLower() == "sodium").amount)) ?? -1;
                }
                //if values still not found, check bad list
                if(food.bad != null)
                {
                    phosphorus = phosphorus == -1 ? (int?)Math.Round(double.Parse(food.bad.SingleOrDefault(n => n.title.ToLower() == "phosphorus").amount)) ?? -1 : phosphorus;

                    potassium = potassium == -1 ? (int?)Math.Round(double.Parse(food.bad.SingleOrDefault(n => n.title.ToLower() == "potassium").amount)) ?? -1 : potassium;

                    sodium = sodium == -1 ? (int?)Math.Round(double.Parse(food.bad.SingleOrDefault(n => n.title.ToLower() == "sodium").amount)) ?? -1 : sodium;

                }
            }
            if(food.weightPerServing != null)
            {
                servingSize = food.weightPerServing.amount.ToString();
                servingSizeUnit = food.weightPerServing.unit;
            }
            return new NutritionFacts()
            {
                ServingSize = servingSize,
                ServingSizeUnit = servingSizeUnit,
                CaloriesPerServing = calories,
                CarbohydratesPerServing = carbohydrates,
                ProteinPerServing = protein,
                FatPerServing = fat,
                PhosphorusPerServing = phosphorus == -1 ? 0 : phosphorus,
                PotassiumPerServing = potassium == -1 ? 0: potassium,
                SodiumPerServing = sodium == -1 ? 0 : sodium
            };
        }
    }

    public class SpoonacularFood
    {
        public string calories { get; set; }
        public string carbs { get; set; }
        public string fat { get; set; }
        public string protein { get; set; }
        public List<Bad> bad { get; set; }
        public List<Good> good { get; set; }
        public List<Nutrient>? nutrients { get; set; }
        public List<Property>? properties { get; set; }
        public List<Flavonoid>? flavonoids { get; set; }
        public List<SPIngredient>? ingredients { get; set; }
        public CaloricBreakdown? caloricBreakdown { get; set; }
        public WeightPerServing? weightPerServing { get; set; }
        public long? expires { get; set; }
        public bool? isStale { get; set; }
    }

    public class WeightPerServing
    {
        public int amount { get; set; }
        public string unit { get; set; }
    }
}
