using Microsoft.EntityFrameworkCore;
using Spotify.DAL.Entities;

namespace Spotify.DAL.Repositories.Genre
{
    public class GenreRepository
        : GenericRepository<GenreEntity>, IGenreRepository
    {
        private readonly AppDbContext _context;

        public GenreRepository(AppDbContext context)
            :base(context) 
        {
            _context = context;
        }

        public IQueryable<GenreEntity> Genres => GetAll();

        public async Task<GenreEntity?> GetByNameAsync(string name)
        {
            return await Genres.FirstOrDefaultAsync(g => g.NormalizedName == name.ToUpper());
        }

        public Task<bool> IsExistsAsync(string name)
        {
            return Genres
                .AnyAsync(g => g.NormalizedName == name.ToUpper());
        }
    }
}
