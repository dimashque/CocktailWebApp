using CocktailWebApp.Models;
using Microsoft.Identity.Client;
using CocktailWebApp.Data.Enum;

namespace CocktailWebApp.ViewModel
{
    public class FeedViewModel
    {
       public int CocktailID { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Alcoholic { get; set; }
        public string? ImageUrl { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? UserName { get; set; }
        public Rank? Rank { get; set; }
        public int LikesCount { get; set; }

        public int BookmarksCount { get; set; }

        public ICollection<AppUser> LikedByUsers { get; set; } = new List<AppUser>();
        public ICollection<AppUser> BookedmarkedByUsers { get; set; } = new List<AppUser>();    

        public LikeViewModel LikeVM { get; set; } = new LikeViewModel();
        public BookmarkViewModel BookmarkVM { get; set; } = new BookmarkViewModel();


    }
}
