using ComicronVote.DTOs;
using ComicronVote.Models;
using ComicronVote.Repository;

namespace ComicronVote.Services
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _repository;

        public FilmService(IFilmRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Film>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Film> GetByCodiceAsync(string codice)
        {
            return await _repository.GetByCodiceAsync(codice);
        }

        public async Task<Film> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task InsertAsync(Film entity)
        {
            await _repository.InsertAsync(entity);
        }
    }
}
