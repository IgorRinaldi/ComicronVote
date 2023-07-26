using ComicronVote.Context;
using ComicronVote.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicronVote.Repository
{
    public class FilmRepository : IFilmRepository
    {
        private readonly ComicronDB comicronDB;
        private readonly DbSet<Film> filmSet;

        public FilmRepository(ComicronDB comicronDB)
        {
            this.comicronDB = comicronDB;
            this.filmSet = comicronDB.Set<Film>();
        }

        public async Task<IEnumerable<Film>> GetAllAsync()
        {
            return await filmSet.ToListAsync();
        }

        public async Task<Film> GetByCodiceAsync(string codice)
        {
            return await filmSet.AsNoTracking().SingleOrDefaultAsync(x => x.Codice.Equals(codice));
        }

        public async Task<Film> GetByIdAsync(Guid id)
        {
            return await filmSet.Include(x => x.Voti).SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task InsertAsync(Film entity)
        {
            filmSet.Attach(entity);
            await comicronDB.SaveChangesAsync();
        }
    }
}
