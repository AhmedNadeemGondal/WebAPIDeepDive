using System.ComponentModel.DataAnnotations;
using WebAPIDeepDive.Models.Validations;

namespace WebAPIDeepDive.Models
{
    public class Shirt
    {
        // Model validation implemented using
        // property annotations.
        // These do not change the nature of the class
        // The class in this example is a simple POCO
        
        public int ShirtId { get; set; }

        [Required]
        public string? Brand { get; set; }

        [Required]
        public string? Color { get; set; }

        [Shirt_EnsureCorrectSizing]
        public int? Size { get; set; }

        [Required]
        public string? Gender { get; set; }

        public double? price { get; set; }
    }
}
