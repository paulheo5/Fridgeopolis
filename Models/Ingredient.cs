using System.ComponentModel.DataAnnotations;

namespace Fridgeopolis.Models
{
    public class Ingredient
    {
        [Required(ErrorMessage = "Please fill in text box.")]
        public string ingredients { get; set; }
    }
}
