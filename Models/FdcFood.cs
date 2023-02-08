namespace Fridgeopolis.Models
{
    public class FoodNutrient
    {
        public int nutrientId { get; set; }
        public string nutrientName { get; set; }
        public string nutrientNumber { get; set; }
        public string unitName { get; set; }
        public string derivationCode { get; set; }
        public string derivationDescription { get; set; }
        public int derivationId { get; set; }
        public double value { get; set; }
        public int foodNutrientSourceId { get; set; }
        public string foodNutrientSourceCode { get; set; }
        public string foodNutrientSourceDescription { get; set; }
        public int rank { get; set; }
        public int indentLevel { get; set; }
        public int foodNutrientId { get; set; }
        public int? percentDailyValue { get; set; }
    }

    public class FdcFood
    {
        public int fdcId { get; set; }
        public string description { get; set; }
        public string lowercaseDescription { get; set; }
        public string dataType { get; set; }
        public string gtinUpc { get; set; }
        public string publishedDate { get; set; }
        public string brandOwner { get; set; }
        public string brandName { get; set; }
        public string ingredients { get; set; }
        public string marketCountry { get; set; }
        public string foodCategory { get; set; }
        public string modifiedDate { get; set; }
        public string dataSource { get; set; }
        public string packageWeight { get; set; }
        public string servingSizeUnit { get; set; }
        public double servingSize { get; set; }
        public List<string> tradeChannels { get; set; }
        public string allHighlightFields { get; set; }
        public double score { get; set; }
        public List<object> microbes { get; set; }
        public List<FoodNutrient> foodNutrients { get; set; }
        public List<object> finalFoodInputFoods { get; set; }
        public List<object> foodMeasures { get; set; }
        public List<object> foodAttributes { get; set; }
        public List<object> foodAttributeTypes { get; set; }
        public List<object> foodVersionIds { get; set; }
    }
}
