using CocktailWebApp.Data.Dtos;
using CocktailWebApp.Helpers;
using CocktailWebApp.Interfaces;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Linq;

namespace CocktailWebApp.Services
{
    public class CocktailService : ICocktailService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = " https://www.thecocktaildb.com/api/json/v1/1/";

        public CocktailService(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        private async Task<T> FetchFromApiAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}{endpoint}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        public async Task<List<CocktailCategoryDto>> GetCategoriesAsync()
        {
        
            var result = await FetchFromApiAsync<CocktailCatergoryResponse>("list.php?c=list");



            return result.CocktailCategories ?? new List<CocktailCategoryDto>(); ;

        }

        public async Task<List<DrinkDto>> GetDrinksByCategoryAsync(string id)
        {
          

            var result = await FetchFromApiAsync<DrinksResponse>(($"filter.php?c={id}"));

            return result.Drinks ?? new List<DrinkDto>(); 
        }

        public async Task<DrinkDetailDto> GetDrinkByIdAsync(string id)
        {
           
            var result = await FetchFromApiAsync<DrinkDetailResponse>(($"lookup.php?i={id}"));

            return result?.Drinks?.FirstOrDefault() ?? new DrinkDetailDto(); ;

        }

        public async Task<List<DrinkDetailDto>> GetDrinksByNameAsync(string id)
        {
            var result = await FetchFromApiAsync<DrinkDetailResponse>($"search.php?s={id}");
            return result.Drinks ?? new List<DrinkDetailDto>();
        }
    }
}
