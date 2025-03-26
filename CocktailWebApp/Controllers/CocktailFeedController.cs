using CocktailWebApp.Data;
using CocktailWebApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using CocktailWebApp.Models;
using CocktailWebApp.ViewModel;

namespace CocktailWebApp.Controllers
{
    public class CocktailFeedController : Controller
    {
        public void MapUsersToVM(List<AppUser> appUsers, List<FeedViewModel> feedVM)
        {
            foreach (AppUser user in appUsers)
            {
                var userFeedVm = new FeedViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Rank = user.Rank,
                    ImageUrl = user.ProfileImageUrl,
                    CreatedCocktails = user.CreatedCocktails
                };

                feedVM.Add(userFeedVm);
            }
        }
        private readonly ICocktailFeedRepository _cocktailFeedRepository;

        public CocktailFeedController (ICocktailFeedRepository cocktailFeedRepository)
        {
            _cocktailFeedRepository = cocktailFeedRepository;
            
        }
        public async Task <IActionResult> Index()
        {
            var users = await _cocktailFeedRepository.GetAllUsersAsync();

            if (users.Count() == 0) return RedirectToAction("Category", "Cocktail");

            var curUsersFeedVM = new List<FeedViewModel>();

            MapUsersToVM(users, curUsersFeedVM);
            
            return View(curUsersFeedVM);
        }
    }
}
