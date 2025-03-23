using System.ComponentModel.DataAnnotations;

namespace CocktailWebApp.Models
{
    public class Ingredient
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Cocktail> Cocktails { get; set; } = new List<Cocktail>();
    }
}
