using CocktailWebApp.Data;
using CocktailWebApp.Interfaces;
using CocktailWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CocktailWebApp.Repository
{
    public class CocktailRepository : ICocktailRepository
    {
        private readonly AppDbContext _context;

        public CocktailRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Cocktail>> GetAllAsync()
        {
            return await _context.Cocktails.ToListAsync();
        }

        public async Task<Cocktail> GetByIdAsync(int id)
        {
            return await _context.Cocktails.Include(i => i.Ingredients).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cocktail> GetByNameAsync(string id)
        {
            return await _context.Cocktails.FirstOrDefaultAsync(x => x.Name.Contains(id));
        }

        public async Task<bool> SaveAsync()
        {
            var saved = _context.SaveChangesAsync();
            return await saved > 0;
        }

        public async Task<bool> Update(Cocktail cocktail)
        {
            _context.Update(cocktail);
            return await SaveAsync();
        }

        public async Task<bool> Add(Cocktail cocktail)
        {
            _context.Add(cocktail);
            return await SaveAsync(); ;
        }

        public async Task<bool> Delete(Cocktail cocktail)
        {
            _context.Remove(cocktail);
            return await SaveAsync();
        }
    }
}
