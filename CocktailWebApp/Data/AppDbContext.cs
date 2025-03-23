using Microsoft.EntityFrameworkCore;
using CocktailWebApp.Models;
using Microsoft.Extensions.Hosting;

namespace CocktailWebApp.Data
{
    
    public class AppDbContext : DbContext
    {
        public DbSet<Cocktail> Cocktails { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<CocktailIngredient> CocktailIngredient { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cocktail>()
                .HasMany(e => e.Ingredients)
                .WithMany(e => e.Cocktails)
                .UsingEntity<CocktailIngredient>();

            

            base.OnModelCreating(modelBuilder);
        }
    }
}
