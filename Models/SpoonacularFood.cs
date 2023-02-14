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

    public class Ingredient
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
        public List<Ingredient>? ingredients { get; set; }
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
