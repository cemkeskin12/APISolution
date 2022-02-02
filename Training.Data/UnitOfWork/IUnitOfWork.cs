using Training.Data.Repositories.Abstract;

namespace Training.Data.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IBookRepository Books { get; }
        IAuthorRepository Author { get; }
        Task<int> SaveAsync();
        int Save();
    }
}
