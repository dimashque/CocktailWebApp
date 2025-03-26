using CocktailWebApp.Models;
using Microsoft.Identity.Client;
using System.Threading.Tasks;

namespace CocktailWebApp.Interfaces
{
    public interface ICocktailFeedRepository
    {
        Task<List<AppUser>> GetAllUsersAsync();
        Task<List<Cocktail>> GetAllCreatedCocktailsAsync();

        Task LikeUnlikeAsync(int id, string curUserId);
        Task BookUnBookMark(int id, string curUserId);
    }
}
