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
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
