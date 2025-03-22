using CocktailWebApp.Data.Dtos;
using System.Text.Json.Serialization;

namespace CocktailWebApp.Helpers
{
    public class CocktailCatergoryResponse
    {
        [JsonPropertyName("drinks")]
        public List<CocktailCategoryDto>? CocktailCategories { get; set; }
    }
}
