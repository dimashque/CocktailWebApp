using CocktailWebApp.Models;

namespace CocktailWebApp.Interfaces
{
    public interface IIngredientRepository
    {
        Task<List<Ingredient>> GetAllAsync();

        Task<Ingredient> GetByIdAsync(int id);
        Task<Ingredient> GetByNameAsync(string id);

        Task<bool> Add(Ingredient ingredient);

        Task<bool> Update(Ingredient ingredient);
        Task<bool> Delete(Ingredient ingredient);

        Task<bool> SaveAsync();
    }
}
