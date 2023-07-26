using ComicronVote.DTOs;
using ComicronVote.Models;

namespace ComicronVote.Services
{
    public interface IVotoService : IService<VotoDTO>
    {
        Task<IEnumerable<VotoDTO>> GetAllByFilmIdAsync(Guid id);
        
        Task<int> SommaVotiByCodiceFilmAsync(string codice);
    }
}
