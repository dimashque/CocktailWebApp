using System.Text.Json.Serialization;

namespace CocktailWebApp.Data.Dtos
{
    public class DrinkDto
    {
        [JsonPropertyName("strDrink")]
        public string? Name { get; set; }

        [JsonPropertyName("strDrinkThumb")]
        public string? ImageUrl { get; set; }


        [JsonPropertyName("idDrink")]
        public string? Id { get; set; }

    }
}
