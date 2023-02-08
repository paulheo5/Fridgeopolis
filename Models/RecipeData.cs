
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Fridgeopolis.Models
{
    public class RecipeData
    {
        //[JsonProperty("id")]
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }
        public string Image { get; set; }

        public string ReadyInMinutes { get; set; }

        public string Summary { get; set; }

        public List<Datum> Steps { get; set; }

        //[JsonProperty("sourceUrl")]
        public string SourceUrl { get; set; }

    }
    public class Datum
        
    {
        public int id { get; set; }
        public string step { get; set;}
    }
}
