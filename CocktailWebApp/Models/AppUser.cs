using Microsoft.AspNetCore.Identity;
using CocktailWebApp.Data.Enum;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;

namespace CocktailWebApp.Models
{
    public class AppUser : IdentityUser
    {

        public string? ProfileImageUrl { get; set; }

        public Rank? Rank { get; set; }

             
        public ICollection<Cocktail>? CreatedCocktails { get; set; } = new List<Cocktail>();
        public ICollection<Cocktail>? LikedCocktails { get; set; } = new List<Cocktail>() ;

        public ICollection<Cocktail>? BookmarkedCocktails { get; set; } = new List<Cocktail>();
    }
}
