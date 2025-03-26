using System.ComponentModel.DataAnnotations;

namespace CocktailWebApp.Models
{
    public class Cocktail
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Alcoholic { get; set; }

        public string? Glass { get; set; }
        public string? Instructions { get; set; }
        public string? ImageUrl { get; set; }

        public string? CreatorId { get; set; }

        public AppUser? Creator { get; set; }

        public DateTime? CreatedDate { get; set; }
        public ICollection<AppUser> LikedByUsers { get; set; }  = new List<AppUser>();
        public ICollection<AppUser> BookedmarkedByUsers { get; set; } = new List<AppUser>();
        public ICollection<CocktailIngredient> CocktailIngredients { get; set; } = new List<CocktailIngredient>();
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
