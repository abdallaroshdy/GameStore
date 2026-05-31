using GameStore.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace GameStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {

       private static readonly List<GameDTO> games = new List<GameDTO>
            {
                new GameDTO(1,  "The Legend of Zelda: Breath of the Wild", "Action-Adventure", 59.99m,  new DateOnly(2017, 3, 3)),
                new GameDTO(2,  "Elden Ring",                              "Action RPG",        59.99m,  new DateOnly(2022, 2, 25)),
                new GameDTO(3,  "Red Dead Redemption 2",                   "Action-Adventure", 49.99m,  new DateOnly(2018, 10, 26)),
                new GameDTO(4,  "Cyberpunk 2077",                          "Action RPG",        39.99m,  new DateOnly(2020, 12, 10)),
                new GameDTO(5,  "God of War",                              "Action-Adventure", 49.99m,  new DateOnly(2018, 4, 20)),
                new GameDTO(6,  "Minecraft",                               "Sandbox",           26.95m,  new DateOnly(2011, 11, 18)),
                new GameDTO(7,  "Grand Theft Auto V",                      "Action-Adventure", 29.99m,  new DateOnly(2013, 9, 17)),
                new GameDTO(8,  "The Witcher 3: Wild Hunt",                "Action RPG",        39.99m,  new DateOnly(2015, 5, 19)),
                new GameDTO(9,  "Hades",                                   "Roguelike",         24.99m,  new DateOnly(2020, 9, 17)),
                new GameDTO(10, "Hollow Knight",                           "Metroidvania",      14.99m,  new DateOnly(2017, 2, 24)),
                new GameDTO(11, "Stardew Valley",                          "Simulation",        13.99m,  new DateOnly(2016, 2, 26)),
                new GameDTO(12, "Among Us",                                "Party",              5.99m,  new DateOnly(2018, 6, 15)),
                new GameDTO(13, "Sekiro: Shadows Die Twice",               "Action RPG",        59.99m,  new DateOnly(2019, 3, 22)),
                new GameDTO(14, "Death Stranding",                         "Action",            29.99m,  new DateOnly(2019, 11, 8)),
                new GameDTO(15, "Disco Elysium",                           "RPG",               39.99m,  new DateOnly(2019, 10, 15)),
                new GameDTO(16, "Celeste",                                 "Platformer",        19.99m,  new DateOnly(2018, 1, 25)),
                new GameDTO(17, "Doom Eternal",                            "FPS",               59.99m,  new DateOnly(2020, 3, 20)),
                new GameDTO(18, "Overwatch 2",                             "FPS",                0.00m,  new DateOnly(2022, 10, 4)),
                new GameDTO(19, "League of Legends",                       "MOBA",               0.00m,  new DateOnly(2009, 10, 27)),
                new GameDTO(20, "Counter-Strike 2",                        "FPS",                0.00m,  new DateOnly(2023, 9, 27)),
            };
       
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(games);
        }

        [HttpGet("{id}" , Name ="GetGame")]
        public IActionResult GetbyId(int id)
        {
            var game = games.FirstOrDefault(i => i.Id == id);
            if (game is null)
                return NotFound();

            return Ok(game);
        }

        [HttpPost]
        public IActionResult AddNewGame(CreateGameDTO game)
        {
            var newGame = new GameDTO(
                Id:games.Count() +1 , 
                Name: game.Name,
                Genre:game.Genre,
                Price:game.Price,
                RelaseDate: game.RelaseDate);

            games.Add(newGame);

            return CreatedAtAction(nameof(GetbyId) ,new {id = newGame.Id} , newGame); 
        }


        [HttpPut("{id}")]
        public IActionResult Update (int id , CreateGameDTO updatedgame)
        {
            var game = games.FirstOrDefault(i => i.Id == id);
            
            if (game is null)
                return NotFound();

            game = new(
                id,
                updatedgame.Name,
                updatedgame.Genre,
                updatedgame.Price,
                updatedgame.RelaseDate
            );

            return NoContent();

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            
            var game = games.FirstOrDefault(i => i.Id==id);
            if (game is null)
                return NotFound();

            games.Remove(game);

            return NoContent();
        }
    }
}
