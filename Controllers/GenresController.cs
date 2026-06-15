using GameStore.Data;
using GameStore.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenresController(GamesDBContext dBContext) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await dBContext.Genres.Select(g => new GenreDto(g.Id , g.Name))
                                        .AsNoTracking()
                                        .ToListAsync();

            return CreatedAtAction(nameof(GetAllGenres) , genres);
        }

    }
}
