using GameStore.Dtos;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data.DataSeeding
{
    public static class GameSeeder
    {
        public static void DataSeeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre {Id =  1 , Name = "Action-Adventure" }
                , new Genre { Id = 2, Name = "Action RPG" }
                , new Genre { Id = 3, Name = "Sandbox" }
            );

            modelBuilder.Entity<Game>().HasData(new Game
            {
                Id = 1,
                Name = "The Legend of Zelda: Breath of the Wild",
                GenreId = 1,
                Price = 59.99m,
                RelaseDate = new DateOnly(2017, 3, 3)
            },
            new Game { Id = 2, Name = "Elden Ring", GenreId = 2, Price = 59.99m, RelaseDate = new DateOnly(2022, 2, 25) },
            new Game { Id = 3, Name = "Red Dead Redemption 2", GenreId = 1, Price = 49.99m, RelaseDate = new DateOnly(2018, 10, 26) }
            );

        }
    }
}
