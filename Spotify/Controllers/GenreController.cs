using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Spotify.DAL.Repositories.Genre;

namespace Spotify.Controllers
{
    [ApiController]
    [Route("api/genre")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;
        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var entities = await _genreRepository.Genres.ToListAsync();
            return Ok(entities);
        }
    }
}
