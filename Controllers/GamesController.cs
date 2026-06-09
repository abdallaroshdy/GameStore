using GameStore.Data;
using GameStore.Dtos;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq;
using System.Xml.Linq;

namespace GameStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController(GamesDBContext dBContext) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var gamesDTO = await dBContext.Games.Include(g => g.Genre)
                                                .Select(game => new GameDTO(game.Id,
                                                        game.Name,
                                                        game.Genre!.Name,
                                                        game.Price,
                                                        game.RelaseDate))
                                                .AsNoTracking()
                                                .ToListAsync();
            return Ok(gamesDTO);
        }

        [HttpGet("{id}" , Name ="GetGame")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var game = await dBContext.Games.FirstOrDefaultAsync(i => i.Id == id);

            if (game is null)
                return NotFound();

            var gameDTO = new GameDetilesDTO(
                game.Id,
                game.Name,
                game.GenreId,
                game.Price,
                game.RelaseDate);

            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewGame(CreateGameDTO game)
        {
            var newGame = new Game { 
                Name = game.Name,
               GenreId = game.GenreId,
                Price = game.Price,
                RelaseDate = game.RelaseDate
            };

            await dBContext.Games.AddAsync(newGame);
            await dBContext.SaveChangesAsync();

            var gameDTO = new GameDetilesDTO (
            newGame.Id,
            newGame.Name,
            newGame.GenreId,
            newGame.Price,
            newGame.RelaseDate
            );
            return CreatedAtAction(nameof(GetbyId) ,new {id = gameDTO.Id} , gameDTO); 
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateGameDTO updatedgame)
        {
            var game = await dBContext.Games.FindAsync(id);

            if (game is null) return NotFound();

            game.Name = updatedgame.Name;
            game.GenreId = updatedgame.GenreId;
            game.Price = updatedgame.Price;
            game.RelaseDate = updatedgame.RelaseDate;

            dBContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await dBContext.Games.Where(g => g.Id == id).ExecuteDeleteAsync();

            return NoContent();
        }
    }
}
