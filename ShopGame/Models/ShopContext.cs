using Microsoft.EntityFrameworkCore;

namespace ShopGame.Models
{
    public class ShopContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
