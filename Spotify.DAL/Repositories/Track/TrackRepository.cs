using Spotify.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Spotify.DAL.Repositories.Track
{
    public class TrackRepository
        : GenericRepository<TrackEntity>, ITrackRepository
    {
        private readonly AppDbContext _context;
        public TrackRepository(AppDbContext context)
            : base(context) 
        {
            _context = context;
        }

        public IQueryable<TrackEntity> Tracks => GetAll();

        public void AddArtist(string trackId ,string artistId)
        {
            var track = Tracks
                .Include(t => t.Artists)
                .FirstOrDefault(t => t.Id == trackId);

            var artist = _context.Artists.FirstOrDefault(a => a.Id == artistId);

            if (track == null || artist == null)
            {
                return;
            }

            if(!track.Artists.Any(a => a.Id == artist.Id))
            {
                track.Artists.Add(artist);
                _context.SaveChanges();
            }
        }

        public async Task<ICollection<TrackEntity>> GetByArtistAsync(string artistName)
        {
            
            return await Tracks
                .Include(t => t.Artists)
                .Where(t => t.Artists.Any(a => a.Name == artistName))
                .ToListAsync();

            
        }

        public async Task<ICollection<TrackEntity>> GetByGenreAsync(string genreName)
        {
            return await Tracks
                .Include(t => t.Genre)
                .Where(t => t.Genre != null &&
                            t.Genre.NormalizedName.ToLower() == genreName.ToLower())
                .ToListAsync();
        }

        public async Task<ICollection<TrackEntity>> GetByTitleAsync(string title)
        {
            return await Tracks
                .Where(t => t.Title == title)
                .ToListAsync();
        }

        public Task<bool> IsExistsAsync(string title)
        {
            return Tracks
                .AnyAsync(t => t.Title == title);
        }
    }
}
