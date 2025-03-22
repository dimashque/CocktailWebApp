using CocktailWebApp.Data.Dtos;
using System.Text.Json.Serialization;

namespace CocktailWebApp.Helpers
{
    public class DrinkDetailResponse
    {
        [JsonPropertyName("drinks")]
        public List<DrinkDetailDto>? Drinks { get; set; }
    }
}
