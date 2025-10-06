using Microsoft.AspNetCore.Mvc;
using Spotify.DAL.Repositories.Artist;
using Microsoft.EntityFrameworkCore;

namespace Spotify.Controllers
{
    [ApiController]
    [Route("api/artist")]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository _artistRepository;
        public ArtistController(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var entities = await _artistRepository.Artists.ToListAsync();
            return Ok(entities);
        }
        [HttpGet("tracks/{artistId}")]
        public async Task<IActionResult> GetTracks(string artistId)
        {
            var tracks = await _artistRepository.GetTracksAsync(artistId);
            return Ok(tracks);
        }
        [HttpGet("by-name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var artists = await _artistRepository.GetByNameAsync(name);
            return Ok(artists);
        }
    }
}
