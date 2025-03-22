using CocktailWebApp.Data.Dtos;
using System.Text.Json.Serialization;

namespace CocktailWebApp.Helpers
{
    public class DrinksResponse
    {
        [JsonPropertyName("drinks")]
        public List<DrinkDto>? Drinks { get; set; }
    }
}
