using CocktailWebApp.Data;
using CocktailWebApp.Interfaces;
using CocktailWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CocktailWebApp.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly AppDbContext _context;

        public IngredientRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Ingredient ingredient)
        {
            _context.Add(ingredient);
            return await SaveAsync();
        }

        public async Task<bool> Delete(Ingredient ingredient)
        {
            _context.Remove(ingredient);
            return await SaveAsync();
        }

        public async Task<List<Ingredient>> GetAllAsync()
        {
            return await _context.Ingredients.ToListAsync();
        }

        public async Task<Ingredient> GetByIdAsync(int id)
        {
            return await _context.Ingredients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Ingredient> GetByNameAsync(string id)
        {
           return  await _context.Ingredients.FirstOrDefaultAsync(x => x.Name.Contains(id));
        }

        public async Task <bool> SaveAsync()
        {
            var saved = _context.SaveChangesAsync();
            return await saved > 0;
        }

        public async Task<bool> Update(Ingredient ingredient)
        {
            _context.Update(ingredient);
            return await SaveAsync();
        }
    }
}
