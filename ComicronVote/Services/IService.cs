using ComicronVote.DTOs;

namespace ComicronVote.Services
{
    public interface IService<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);

        Task<IEnumerable<T>> GetAllAsync();

        Task InsertAsync(T entity);
    }
}
