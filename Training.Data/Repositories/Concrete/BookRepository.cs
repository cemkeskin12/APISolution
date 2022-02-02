using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Data.Context;
using Training.Data.Repositories.Abstract;
using Training.Entity.Entities;

namespace Training.Data.Repositories.Concrete
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
              
        }
    }
}
