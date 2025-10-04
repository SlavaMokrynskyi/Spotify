using Spotify.DAL.Entities;

namespace Spotify.DAL.Repositories.Genre
{
    public interface IGenreRepository
        : IGenericRepository<GenreEntity>
    {
        IQueryable<GenreEntity> Genres { get;}
        Task<GenreEntity?> GetByNameAsync(string name);
        Task<bool> IsExistsAsync(string name);

    }
}
