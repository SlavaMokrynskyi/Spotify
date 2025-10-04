using Spotify.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Spotify.DAL.Repositories.Track
{
    public class TrackRepository
        : GenericRepository<TrackEntity>, ITrackRepository
    {
        private readonly AppDbContext _context;
        public TrackRepository(AppDbContext context)
            : base(context) {}

        public IQueryable<TrackEntity> Tracks => GetAll();

        public void AddArtist(string trackId ,ArtistEntity artist)
        {
            var track = Tracks
                .Include(t => t.Artists)
                .FirstOrDefault(t => t.Id == trackId);

            if (track != null)
            {
                track.Artists.Add(artist);
                _context.SaveChanges();
            }
        }

        public async Task<ICollection<TrackEntity>> GetByArtist(string artistName)
        {
            return await Tracks.Where(t => t.Artists.Any(a => a.Name == artistName))
                .ToListAsync();
        }

        public async Task<ICollection<TrackEntity>> GetByGenre(string genre)
        {
          return await Tracks.Where(t => t.Genre.NormalizedName == genre.ToLower())
                .ToListAsync();  
        }

        public async Task<ICollection<TrackEntity>> GetByTitle(string title)
        {
            return await Tracks.Where(t => t.Title == title)
                .ToListAsync();
        }

        public Task<bool> IsExistsAsync(string title)
        {
            return Tracks
                .AnyAsync(t => t.Title == title);
        }
    }
}
