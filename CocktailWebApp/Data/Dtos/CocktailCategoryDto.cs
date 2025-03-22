using Newtonsoft.Json;

namespace CocktailWebApp.Data.Dtos
   
{
    public class CocktailCategoryDto
    {
        [JsonProperty("strCategory")]
        public string strCategory {  get; set; }
    }
}
