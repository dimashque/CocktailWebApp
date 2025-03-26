using Microsoft.EntityFrameworkCore;
using CocktailWebApp.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CocktailWebApp.Data
{
    
    public class AppDbContext : IdentityDbContext<AppUser>
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

            modelBuilder.Entity<Cocktail>()
                .HasOne(e => e.Creator)
                .WithMany(e => e.CreatedCocktails)
                .HasForeignKey(e => e.CreatorId);
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
