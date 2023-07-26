using ComicronVote.Context;
using ComicronVote.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicronVote.Repository
{
    public class VotoRepository : IVotoRepository
    {
        private readonly ComicronDB comicronDB;
        private readonly DbSet<Voto> votoSet;
        private readonly IFilmRepository filmRepository;

        public VotoRepository(ComicronDB comicronDB, IFilmRepository filmRepository)
        {
            this.comicronDB = comicronDB;
            this.votoSet = comicronDB.Set<Voto>();
            this.filmRepository = filmRepository;
        }

        public Task<IEnumerable<Voto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Voto>> GetAllByFilmIdAsync(Guid id)
        {
            return await votoSet
                .AsNoTracking().
                Where(x => x.FilmId.Equals(id))
                .ToListAsync();
        }

        public async Task<Voto> GetByIdAsync(Guid id)
        {
            return await votoSet.AsNoTracking().
                SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task InsertAsync(Voto entity)
        {
            votoSet.Attach(entity);
            await comicronDB.SaveChangesAsync();
        }

        public async Task<int> SommaVotiByFilmId(string codice)
        {
            int somma = 0;
            
            Film film = await filmRepository.GetByCodiceAsync(codice);
            IEnumerable<Voto> lista = await GetAllByFilmIdAsync(film.Id);

            foreach (var item in lista)
            {
                somma = somma + item.voto;
            }
            
            return somma;
        }
    }
}
