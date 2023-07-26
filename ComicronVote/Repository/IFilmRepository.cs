using ComicronVote.Models;
using System.Collections;

namespace ComicronVote.Repository
{
    public interface IFilmRepository : IRepository<Film>
    {
        Task<Film> GetByCodiceAsync(string codice);
    }
}
