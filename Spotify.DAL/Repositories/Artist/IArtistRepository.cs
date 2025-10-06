using Spotify.DAL.Entities;

namespace Spotify.DAL.Repositories.Artist
{
    public interface IArtistRepository
        : IGenericRepository<ArtistEntity>
    {
        IQueryable<ArtistEntity> Artists { get; }
        Task<ICollection<ArtistEntity>> GetByNameAsync(string name);
        Task<ICollection<TrackEntity>> GetTracksAsync(string artistId);
        Task<bool> IsExistsAsync(string name);
    }
}
