using System.ComponentModel.DataAnnotations;

namespace CocktailWebApp.ViewModel
{
    public class CreateCocktailViewModel
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Alcoholic { get; set; }

        public string? Glass { get; set; }
        public string? Instructions { get; set; }
        public string? ImageUrl { get; set; }

        public List<CocktailIngredientViewModel> Ingredients { get; set; } = new List<CocktailIngredientViewModel>();
    }
}
