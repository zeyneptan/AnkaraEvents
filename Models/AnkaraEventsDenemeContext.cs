using Microsoft.EntityFrameworkCore;

    

namespace AnkaraEventsDeneme.Models
{
    public class AnkaraEventsDenemeContext : DbContext
    {

        public DbSet<User> User { get; set; }
        public DbSet<Event> Events { get; set; } 
        public DbSet<FavoriteEvent> FavoriteEvents { get; set; }

        public DbSet<Event> CinemaEvents { get; set; }
        public DbSet<Event> TheatreEvents { get; set; }
        public DbSet<Event> ConcertEvents { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-H3DFLTH\\SQLEXPRESS;Database=EventDeneme;Trusted_Connection=True;");


        }
    }
}
