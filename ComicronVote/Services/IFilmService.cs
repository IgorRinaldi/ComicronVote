using ComicronVote.Models;

namespace ComicronVote.Services
{
    public interface IFilmService : IService<Film>
    {
        Task<Film> GetByCodiceAsync(string codice);
    }
}
