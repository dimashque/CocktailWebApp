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
        public void MapCreatedCocktailsToVM(List<Cocktail> cocktails, List<FeedViewModel> feedVM)
        {
            foreach (var cocktail in cocktails)
            {
                var cocktailFeedVM = new FeedViewModel
                {
                    CocktailID = cocktail.Id,
                    Name = cocktail.Name,
                    Category = cocktail.Category,
                    Alcoholic = cocktail.Alcoholic,
                    ImageUrl = cocktail.ImageUrl,
                    UserName = cocktail.Creator.UserName,
                    Rank = cocktail.Creator.Rank,
                    LikesCount = cocktail.LikedByUsers.Count,
                    BookmarksCount = cocktail.BookedmarkedByUsers.Count,
                    CreatedDate = cocktail.CreatedDate,
                    LikedByUsers = cocktail.LikedByUsers,
                    BookedmarkedByUsers =cocktail.BookedmarkedByUsers,

                };
                feedVM.Add(cocktailFeedVM);
            }
        }
        private readonly ICocktailFeedRepository _cocktailFeedRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CocktailFeedController (ICocktailFeedRepository cocktailFeedRepository, IHttpContextAccessor httpContextAccessor)
        {
            _cocktailFeedRepository = cocktailFeedRepository;
            _httpContextAccessor = httpContextAccessor;
            
        }
        public async Task <IActionResult> Index()
        {
            var createdCocktails = await _cocktailFeedRepository.GetAllCreatedCocktailsAsync();

            if (createdCocktails == null) { return View("Error"); }
            List<FeedViewModel> feeds = new List<FeedViewModel>();

            MapCreatedCocktailsToVM(createdCocktails, feeds);
           
            
            return View(feeds);
        }
        [HttpPost]
        public async Task <IActionResult> Cheers(LikeViewModel likeVM)
        {
            if(!ModelState.IsValid) return View("Error");

            var curUserID = _httpContextAccessor.HttpContext.User.GetUserID();


            await _cocktailFeedRepository.LikeUnlikeAsync(likeVM.CocktailId, curUserID);

            return RedirectToAction("RecipeDetail", "Cocktail", new { id = likeVM.CocktailId });
        }

        [HttpPost]
        public async Task<IActionResult> Bookmark(LikeViewModel likeVM)
        {
            if (!ModelState.IsValid) return View("Error");

            var curUserID = _httpContextAccessor.HttpContext.User.GetUserID();


            await _cocktailFeedRepository.BookUnBookMark(likeVM.CocktailId, curUserID);

            return RedirectToAction("RecipeDetail", "Cocktail", new {id = likeVM.CocktailId});


        }
    }
}
