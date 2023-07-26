using ComicronVote.Models;

namespace ComicronVote.Repository
{
    public interface IVotoRepository : IRepository<Voto>
    {
        Task<IEnumerable<Voto>> GetAllByFilmIdAsync(Guid id);

        Task<int> SommaVotiByFilmId(string codice);
    }
}
