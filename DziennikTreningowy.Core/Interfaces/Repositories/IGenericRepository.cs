using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DziennikTreningowy.Core.Interfaces
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        T Add(T entity);
        Task<T> AddAsync(T entity);
        int Count();
        Task<int> CountAsync();
        int Delete(T entity);
        Task<int> DeleteAsync(T entity);
        int DeleteById(int id);
        Task<int> DeleteByIdAsync(int id);
        T Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        T Get(int id);
        Task<T> GetAsync(int id);
        IQueryable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();  
        void Save();
        Task<int> SaveAsync();
        T Update(T entity);
        Task<T> UpdateAsync(T entity);
    }
}
