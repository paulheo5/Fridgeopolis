namespace Fridgeopolis.Models
{
    public class Bad
    {
        public string title { get; set; }
        public string amount { get; set; }
        public bool indented { get; set; }
        public double percentOfDailyNeeds { get; set; }
    }

    public class Good
    {
        public string title { get; set; }
        public string amount { get; set; }
        public bool indented { get; set; }
        public double percentOfDailyNeeds { get; set; }
    }

    public class SpoonacularFood
    {
        public string calories { get; set; }
        public string carbs { get; set; }
        public string fat { get; set; }
        public string protein { get; set; }
        public List<Bad> bad { get; set; }
        public List<Good> good { get; set; }
        public long expires { get; set; }
        public bool isStale { get; set; }
    }
}
