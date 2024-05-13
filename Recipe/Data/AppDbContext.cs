using System.Data.Entity;

namespace Recipe.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=Recipes")
        {
        }

        public DbSet<Recipe.Models.Recipe> Recipes { get; set; }
    }

}