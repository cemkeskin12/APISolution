using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Data.Context;
using Training.Data.Repositories.Abstract;
using Training.Data.Repositories.Concrete;

namespace Training.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private BookRepository _bookRepository;
        private AuthorRepository _authorRepository;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IBookRepository Books => _bookRepository ?? new BookRepository(_dbContext);
        public IAuthorRepository Author => _authorRepository ?? new AuthorRepository(_dbContext);

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }
    }
}
