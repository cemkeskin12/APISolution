using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Training.Data.Repositories.Abstract
{
    public interface IGenericRepository<T> where T : class, new()
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
        params Expression<Func<T, object>>[] includeProperties);
        Task<T> AddAsync(T entity);
        Task<T> GetByIdAsync(int id);
        T Update(T entity);
        T Delete(T entity);
    }
}
