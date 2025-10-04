using Spotify.DAL.Entities;

namespace Spotify.DAL.Repositories
{
    public interface IGenericRepository<TEntity>
        where TEntity : class, IBaseEntity
    {
        Task CreateAsync(TEntity entity);
        Task CreateRangeAsync(params TEntity[] entities);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(string id);
        IQueryable<TEntity> GetAll();
    }
}
