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
    }
}
