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

            modelBuilder.Entity<AppUser>()
        .HasMany(u => u.LikedCocktails)
        .WithMany(p => p.LikedByUsers)
        .UsingEntity<Like>(
            j => j.HasOne(l => l.cocktail)
                .WithMany()
                .HasForeignKey(l => l.CocktailId),
            j => j.HasOne(l => l.LikedByUser)
                .WithMany()
                .HasForeignKey(l => l.AppUserId),
            j =>
            {
                j.HasKey(l => new { l.AppUserId, l.CocktailId });
                j.Property(l => l.CreatedDate)
                  .HasDefaultValueSql("GETDATE()");  // Default timestamp when the like is created
                j.ToTable("Likes");
            }
        );

            modelBuilder.Entity<AppUser>()
  .HasMany(u => u.BookmarkedCocktails)
  .WithMany(p => p.BookedmarkedByUsers)
  .UsingEntity<Bookmark>(
      j => j.HasOne(l => l.cocktail)
          .WithMany()
          .HasForeignKey(l => l.CocktailId),
      j => j.HasOne(l => l.BookmarkedByUser)
          .WithMany()
          .HasForeignKey(l => l.AppUserId),
      j =>
      {
          j.HasKey(l => new { l.AppUserId, l.CocktailId });
          j.Property(l => l.CreatedDate)
            .HasDefaultValueSql("GETDATE()");  // Default timestamp when the like is created
          j.ToTable("Likes");
      }
  );



            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.BookmarkedCocktails)
                .WithMany(e => e.BookedmarkedByUsers)
                .UsingEntity<Bookmark>();

            modelBuilder.Entity<Cocktail>()
                .HasOne(e => e.Creator)
                .WithMany(e => e.CreatedCocktails)
                .HasForeignKey(e => e.CreatorId);
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
