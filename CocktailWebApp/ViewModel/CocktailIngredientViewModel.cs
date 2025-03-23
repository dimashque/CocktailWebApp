using System.ComponentModel.DataAnnotations;

namespace CocktailWebApp.ViewModel
{
    public class CocktailIngredientViewModel
    {
        [Required]
        public string? Name { get; set; }

        public string? Amount { get; set; }
    }
}
