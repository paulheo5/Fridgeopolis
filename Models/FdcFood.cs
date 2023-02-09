using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Fridgeopolis.Models
{
    /*public class FoodNutrient
    {
        [Key]
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
        [Key]
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
    }*/
    public class Aggregations
    {
        public DataType dataType { get; set; }
        public Nutrients nutrients { get; set; }
    }

    public class DataType
    {
        public int Branded { get; set; }

        [JsonProperty("Survey (FNDDS)")]
        public int SurveyFNDDS { get; set; }

        [JsonProperty("SR Legacy")]
        public int SRLegacy { get; set; }
    }

    public class FinalFoodInputFood
    {
        public string foodDescription { get; set; }
        public double gramWeight { get; set; }
        public int id { get; set; }
        public string portionCode { get; set; }
        public string portionDescription { get; set; }
        public string unit { get; set; }
        public int rank { get; set; }
        public int srCode { get; set; }
        public double value { get; set; }
    }

    public class Food
    {
        public int fdcId { get; set; }
        public string description { get; set; }
        public string lowercaseDescription { get; set; }
        public string commonNames { get; set; }
        public string additionalDescriptions { get; set; }
        public string dataType { get; set; }
        public int foodCode { get; set; }
        public string publishedDate { get; set; }
        public string foodCategory { get; set; }
        public int foodCategoryId { get; set; }
        public string allHighlightFields { get; set; }
        public double score { get; set; }
        public List<object> microbes { get; set; }
        public List<FoodNutrient> foodNutrients { get; set; }
        public List<FinalFoodInputFood> finalFoodInputFoods { get; set; }
        public List<FoodMeasure> foodMeasures { get; set; }
        public List<object> foodAttributes { get; set; }
        public List<FoodAttributeType> foodAttributeTypes { get; set; }
        public List<object> foodVersionIds { get; set; }
        public int? ndbNumber { get; set; }
        public string scientificName { get; set; }
        public string gtinUpc { get; set; }
        public string brandOwner { get; set; }
        public string brandName { get; set; }
        public string ingredients { get; set; }
        public string marketCountry { get; set; }
        public string modifiedDate { get; set; }
        public string dataSource { get; set; }
        public string packageWeight { get; set; }
        public string servingSizeUnit { get; set; }
        public double? servingSize { get; set; }
        public string householdServingFullText { get; set; }
        public string shortDescription { get; set; }
        public List<string> tradeChannels { get; set; }
        public string subbrandName { get; set; }
    }

    public class FoodAttribute
    {
        public string value { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public int? sequenceNumber { get; set; }
    }

    public class FoodAttributeType
    {
        public string name { get; set; }
        public string description { get; set; }
        public int id { get; set; }
        public List<FoodAttribute> foodAttributes { get; set; }
    }

    public class FoodMeasure
    {
        public string disseminationText { get; set; }
        public double gramWeight { get; set; }
        public int id { get; set; }
        public string modifier { get; set; }
        public int rank { get; set; }
        public string measureUnitAbbreviation { get; set; }
        public string measureUnitName { get; set; }
        public int measureUnitId { get; set; }
    }

    public class FoodNutrient
    {
        public int nutrientId { get; set; }
        public string nutrientName { get; set; }
        public string nutrientNumber { get; set; }
        public string unitName { get; set; }
        public double value { get; set; }
        public int rank { get; set; }
        public int indentLevel { get; set; }
        public int foodNutrientId { get; set; }
        public string derivationCode { get; set; }
        public string derivationDescription { get; set; }
        public int? derivationId { get; set; }
        public int? foodNutrientSourceId { get; set; }
        public string foodNutrientSourceCode { get; set; }
        public string foodNutrientSourceDescription { get; set; }
        public int? dataPoints { get; set; }
        public double? min { get; set; }
        public double? max { get; set; }
        public double? percentDailyValue { get; set; }
    }

    public class FoodSearchCriteria
    {
        public string query { get; set; }
        public string generalSearchInput { get; set; }
        public int pageNumber { get; set; }
        public int numberOfResultsPerPage { get; set; }
        public int pageSize { get; set; }
        public bool requireAllWords { get; set; }
    }

    public class Nutrients
    {
    }

    public class FdcResults
    {
        public int totalHits { get; set; }
        public int currentPage { get; set; }
        public int totalPages { get; set; }
        public List<int> pageList { get; set; }
        public FoodSearchCriteria foodSearchCriteria { get; set; }
        public List<Food> foods { get; set; }
        public Aggregations aggregations { get; set; }
    }
}
