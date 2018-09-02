using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ContaCorrente.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class 
    {
        Task<int> AddAsync(T t);
        Task<int> RemoveAsync(T t);
        Task<int> UpdateAsync(T t);
        Task<int> CountAsync();
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> match);
        Task<List<T>> GetAllAsync();
        void Detach(T entity);
    }
}
