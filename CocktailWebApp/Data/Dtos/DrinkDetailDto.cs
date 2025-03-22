using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace CocktailWebApp.Data.Dtos
{
    public class DrinkDetailDto
    {
        [JsonPropertyName("idDrink")]
        public string Id { get; set; }

        [JsonPropertyName("strDrink")]
        public string Name { get; set; }

        [JsonPropertyName("strTags")]
        public string Tags { get; set; }

        [JsonPropertyName("strCategory")]
        public string Category { get; set; }

        [JsonPropertyName("strIBA")]
        public string Iba { get; set; }

        [JsonPropertyName("strAlcoholic")]
        public string Alcoholic { get; set; }

        [JsonPropertyName("strGlass")]
        public string Glass { get; set; }

        [JsonPropertyName("strInstructions")]
        public string Instructions { get; set; }

        [JsonPropertyName("strDrinkThumb")]
        public string DrinkImageUrl { get; set; }

        // List of ingredients and their corresponding measures
        public List<string> Ingredients { get; set; } = new List<string>();

        public List<string> Measures { get; set; } = new List<string>();

        // Populating the ingredients and measures lists
        public void PopulateIngredientsAndMeasures()
        {
            for (int i = 1; i <= 15; i++)
            {
                var ingredient = (string)this.GetType().GetProperty($"Ingredient{i}")?.GetValue(this, null);
                var measure = (string)this.GetType().GetProperty($"Measure{i}")?.GetValue(this, null);

                if (!string.IsNullOrEmpty(ingredient))
                {
                    Ingredients.Add(ingredient);
                    Measures.Add(measure ?? string.Empty); // Add empty string if measure is null
                }
            }
        }

        // Ingredient fields (properties from API response)
        [JsonPropertyName("strIngredient1")]
        public string Ingredient1 { get; set; }

        [JsonPropertyName("strIngredient2")]
        public string Ingredient2 { get; set; }

        [JsonPropertyName("strIngredient3")]
        public string Ingredient3 { get; set; }

        [JsonPropertyName("strIngredient4")]
        public string Ingredient4 { get; set; }

        [JsonPropertyName("strIngredient5")]
        public string Ingredient5 { get; set; }

        [JsonPropertyName("strIngredient6")]
        public string Ingredient6 { get; set; }

        [JsonPropertyName("strIngredient7")]
        public string Ingredient7 { get; set; }

        [JsonPropertyName("strIngredient8")]
        public string Ingredient8 { get; set; }

        [JsonPropertyName("strIngredient9")]
        public string Ingredient9 { get; set; }

        [JsonPropertyName("strIngredient10")]
        public string Ingredient10 { get; set; }

        [JsonPropertyName("strIngredient11")]
        public string Ingredient11 { get; set; }

        [JsonPropertyName("strIngredient12")]
        public string Ingredient12 { get; set; }

        [JsonPropertyName("strIngredient13")]
        public string Ingredient13 { get; set; }

        [JsonPropertyName("strIngredient14")]
        public string Ingredient14 { get; set; }

        [JsonPropertyName("strIngredient15")]
        public string Ingredient15 { get; set; }

        // Measure fields (properties from API response)
        [JsonPropertyName("strMeasure1")]
        public string Measure1 { get; set; }

        [JsonPropertyName("strMeasure2")]
        public string Measure2 { get; set; }

        [JsonPropertyName("strMeasure3")]
        public string Measure3 { get; set; }

        [JsonPropertyName("strMeasure4")]
        public string Measure4 { get; set; }

        [JsonPropertyName("strMeasure5")]
        public string Measure5 { get; set; }

        [JsonPropertyName("strMeasure6")]
        public string Measure6 { get; set; }

        [JsonPropertyName("strMeasure7")]
        public string Measure7 { get; set; }

        [JsonPropertyName("strMeasure8")]
        public string Measure8 { get; set; }

        [JsonPropertyName("strMeasure9")]
        public string Measure9 { get; set; }

        [JsonPropertyName("strMeasure10")]
        public string Measure10 { get; set; }

        [JsonPropertyName("strMeasure11")]
        public string Measure11 { get; set; }

        [JsonPropertyName("strMeasure12")]
        public string Measure12 { get; set; }

        [JsonPropertyName("strMeasure13")]
        public string Measure13 { get; set; }

        [JsonPropertyName("strMeasure14")]
        public string Measure14 { get; set; }

        [JsonPropertyName("strMeasure15")]
        public string Measure15 { get; set; }
    }
}
