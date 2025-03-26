namespace CocktailWebApp.Models
{
    public class Bookmark
    {
        
        public string AppUserId { get; set; }
        public int CocktailId { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public Cocktail? cocktail { get; set; }
        public AppUser? BookmarkedByUser { get; set; }
    }
}
