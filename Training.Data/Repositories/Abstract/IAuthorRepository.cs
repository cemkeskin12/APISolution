using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Data.Repositories.Concrete;
using Training.Entity.Entities;

namespace Training.Data.Repositories.Abstract
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
    }
}
