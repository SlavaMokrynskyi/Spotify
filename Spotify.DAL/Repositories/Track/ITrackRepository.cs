using Spotify.DAL.Entities;


namespace Spotify.DAL.Repositories.Track
{
    public interface ITrackRepository
        : IGenericRepository<TrackEntity>
    {
        IQueryable<TrackEntity> Tracks { get; }
        Task<ICollection<TrackEntity>> GetByTitleAsync(string title);
        Task<ICollection<TrackEntity>> GetByArtistAsync(string artistName);
        Task<ICollection<TrackEntity>> GetByGenreAsync(string genre);
        void AddArtist(string taskId,string artistId);
        Task<bool> IsExistsAsync(string title);
    }
}
