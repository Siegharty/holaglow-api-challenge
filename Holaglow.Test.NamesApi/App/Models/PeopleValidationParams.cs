using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class PeopleValidationParams
    {
        public string Name { get; set; } = string.Empty;

        [RegularExpression("^(M|F)$", ErrorMessage = "El género debe ser 'M' o 'F'.")]
        public string Gender { get; set; } = string.Empty;
    }

}
