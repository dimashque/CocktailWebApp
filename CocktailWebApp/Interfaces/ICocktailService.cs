using CocktailWebApp.Data.Dtos;

namespace CocktailWebApp.Interfaces
{
    public interface ICocktailService
    {
        Task <List<CocktailCategoryDto>> GetCategoriesAsync () ;

        Task<List<DrinkDto>> GetDrinksByCategoryAsync(string id) ;

        Task <DrinkDetailDto> GetDrinkByIdAsync (string id) ;

        Task<List<DrinkDetailDto>> GetDrinksByNameAsync(string id);


    }
}
