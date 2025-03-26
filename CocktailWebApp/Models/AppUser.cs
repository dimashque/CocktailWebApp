using Microsoft.AspNetCore.Identity;
using CocktailWebApp.Data.Enum;

namespace CocktailWebApp.Models
{
    public class AppUser : IdentityUser
    {

        public string? ProfileImageUrl { get; set; }

        public Rank? Rank { get; set; }

             
        public ICollection<Cocktail>? CreatedCocktails { get; set; } = new List<Cocktail>();
    }
}
