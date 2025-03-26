using CocktailWebApp.Models;
using Microsoft.Identity.Client;
using CocktailWebApp.Data.Enum;

namespace CocktailWebApp.ViewModel
{
    public class FeedViewModel
    {
        public string? Id { get; set; }

        public string? UserName { get; set; }

        public string? ImageUrl { get; set; }
        public Rank? Rank { get; set; }

        public ICollection<Cocktail> CreatedCocktails { get; set; } = new List<Cocktail>();
    }
}
