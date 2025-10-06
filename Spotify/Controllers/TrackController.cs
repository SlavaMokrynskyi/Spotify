using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spotify.DAL.Repositories.Track;

namespace Spotify.Controllers
{
    [ApiController]
    [Route("api/track")]
    public class TrackController : ControllerBase
    {
        private readonly ITrackRepository _trackRepository;

        public TrackController(ITrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var entities = await _trackRepository.Tracks.ToListAsync();
            return Ok(entities);
        }
        [HttpGet("by-title/{title}")]
        public async Task<IActionResult> GetByTitleAsync(string title)
        {
            var tracks = await _trackRepository.GetByTitleAsync(title);
            return Ok(tracks);
        }
        [HttpGet("by-artist/{artist}")]
        public async Task<IActionResult> GetByArtistAsync(string artist)
        {
            var tracks = await _trackRepository.GetByArtistAsync(artist);
            return Ok(tracks);
        }
        [HttpGet("by-genre/{genre}")]
        public async Task<IActionResult> GetByGenreAsync(string genre)
        {
            var tracks = await _trackRepository.GetByGenreAsync(genre);
            return Ok(tracks);
        }
        [HttpPost("add-artist/{trackId}/{artistId}")]
        public async Task<IActionResult> AddArtist(string trackId, string artistId)
        {
            _trackRepository.AddArtist(trackId, artistId);
            return Ok();
        }
    }
}
