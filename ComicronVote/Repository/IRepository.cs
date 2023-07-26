namespace ComicronVote.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);

        Task<IEnumerable<T>> GetAllAsync();

        Task InsertAsync(T entity);
    }
}
