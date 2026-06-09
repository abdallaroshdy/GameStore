using GameStore.Data;
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
            var genres = await dBContext.Genres.ToListAsync();
            return CreatedAtAction(nameof(GetAllGenres) , genres);
        }

    }
}
