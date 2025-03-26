using CocktailWebApp.Data;
using CocktailWebApp.Interfaces;
using CocktailWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CocktailWebApp.Repository
{
    public class CocktailFeedRepository : ICocktailFeedRepository
    {
        private readonly AppDbContext _context;

        public CocktailFeedRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<AppUser>> GetAllUsersAsync()
        {
            return await _context.Users.Include( e => e.CreatedCocktails).ToListAsync();
        }

        public async Task<List<Cocktail>> GetAllCreatedCocktailsAsync()
        {
            return await _context.Cocktails
                .Include(e => e.Creator)
                .Include(e => e.LikedByUsers)
                .Include(e => e.BookedmarkedByUsers)
                .Where(e => !string.IsNullOrEmpty(e.CreatorId))
                .OrderByDescending(e => e.CreatedDate)
                .ToListAsync();
        }
        
       public async Task  LikeUnlikeAsync(int id, string curUserId)
        {
            var like = await _context.Likes.FirstOrDefaultAsync(e => e.CocktailId  == id && e.AppUserId.Equals(curUserId));

            if (like == null)
            {
                _context.Likes.Add(new Like { AppUserId = curUserId, CocktailId = id, CreatedDate = DateTime.UtcNow });
            }
            else
            {
                _context.Likes.Remove(like);
            }

            await _context.SaveChangesAsync();


        }

        public async Task BookUnBookMark(int id, string curUserId)
        {
            var bookmark = await _context.Likes.FirstOrDefaultAsync(e => e.CocktailId == id && e.AppUserId.Equals(curUserId));

            if (bookmark == null)
            {
                _context.Bookmarks.Add(new Bookmark { AppUserId = curUserId, CocktailId = id, CreatedDate = DateTime.UtcNow });
            }
            else
            {
                _context.Likes.Remove(bookmark);
            }

            await _context.SaveChangesAsync();


        }
    }
}

