using GameStore.Data.DataSeeding;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data
{
    public class GamesDBContext(DbContextOptions<GamesDBContext> options): DbContext(options) 
    {
        public DbSet<Game> Games => Set<Game>();
        public DbSet<Genre> Genres => Set<Genre>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            GameSeeder.DataSeeding(modelBuilder);

        }
    }
}
