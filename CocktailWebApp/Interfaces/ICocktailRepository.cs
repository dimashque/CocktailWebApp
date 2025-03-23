using CocktailWebApp.Models;

namespace CocktailWebApp.Interfaces
{
    public interface ICocktailRepository
    {
        Task<List<Cocktail>> GetAllAsync();

        Task<Cocktail> GetByIdAsync(int id);
        Task<Cocktail> GetByNameAsync(string id);

        Task<bool> Add(Cocktail cocktail);

        Task<bool> Update(Cocktail cocktail);
        Task<bool> Delete(Cocktail cocktail);

        Task<bool> SaveAsync();
    }
}
