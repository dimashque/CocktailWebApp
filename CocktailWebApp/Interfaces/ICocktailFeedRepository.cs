using CocktailWebApp.Models;

namespace CocktailWebApp.Interfaces
{
    public interface ICocktailFeedRepository
    {
        Task<List<AppUser>> GetAllUsersAsync();
    }
}
