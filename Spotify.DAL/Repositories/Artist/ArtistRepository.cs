using Spotify.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Spotify.DAL.Repositories.Artist
{
    public class ArtistRepository
        : GenericRepository<ArtistEntity>, IArtistRepository
    {
        private readonly AppDbContext _context;
        public ArtistRepository(AppDbContext context)
            : base(context) { }
        public IQueryable<ArtistEntity> Artists => GetAll();

        public async Task<ICollection<ArtistEntity>> GetByNameAsync(string name)
        {
            return await Artists.Where(a => a.Name == name).ToListAsync();
        }

        public async Task<ICollection<TrackEntity>> GetTracks(string artistId)
        {
            return await Artists.Where(a => a.Id == artistId)
                .SelectMany(a => a.Tracks)
                .ToListAsync();
        }

        public Task<bool> IsExistsAsync(string name)
        {
            return Artists
                .AnyAsync(a => a.Name == name);
        }
    }
}
