using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CocktailWebApp.Models
{
    public class CocktailIngredient
    {
        
        public int Id { get; set; }
        
        public int CocktailId { get; set; }
        
        public int IngredientId { get; set; }
        public string? Amount { get; set; }

        public Cocktail? Cocktail { get; set; }

        public Ingredient? Ingredient { get; set; }
    }
}
