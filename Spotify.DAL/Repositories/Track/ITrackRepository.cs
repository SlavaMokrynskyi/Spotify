using Spotify.DAL.Entities;


namespace Spotify.DAL.Repositories.Track
{
    public interface ITrackRepository
        : IGenericRepository<TrackEntity>
    {
        IQueryable<TrackEntity> Tracks { get; }
        Task<ICollection<TrackEntity>> GetByTitle(string title);
        Task<ICollection<TrackEntity>> GetByArtist(string artistName);
        Task<ICollection<TrackEntity>> GetByGenre(string genre);
        void AddArtist(string taskId,ArtistEntity artist);
        Task<bool> IsExistsAsync(string title);
    }
}
