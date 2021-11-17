using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IAsyncRepository<T> where T:class
    {
        // common CRUD operations
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> ListAllAsync();
        Task<IEnumerable<T>> ListAsync( Expression<Func<T, bool>> filter );
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(int id, T entitiy);
        Task<bool> DeleteAsync(int id);

    }
}
