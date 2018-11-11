using DziennikTreningowy.Core.Interfaces;
using DziennikTreningowy.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DziennikTreningowy.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly WorkoutDiaryDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(WorkoutDiaryDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual T Add(T entity)
        {
            T result = _dbSet.Add(entity).Entity;
            _dbContext.SaveChanges();
            return result;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            T result = _dbSet.Add(entity).Entity;
            await _dbContext.SaveChangesAsync();
            return result;
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }

        public virtual int Delete(T entity)
        {
            _dbSet.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public virtual int DeleteById(int id)
        {
            T entityToDelete = _dbSet.Find(id);
            int res = 0;
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
                res = _dbContext.SaveChanges();
            }
            return res;
        }

        public virtual async Task<int> DeleteByIdAsync(int id)
        {
            T entityToDelete = await _dbSet.FindAsync(id);
            int res = 0;
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
                res = await _dbContext.SaveChangesAsync();
            }
            return res;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual T Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.SingleOrDefault(predicate);
        }

        public virtual IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public virtual async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual void Save()
        {
            _dbContext.SaveChanges();
        }

        public virtual async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public virtual T Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            T result = _dbSet.Update(entity).Entity;
            _dbContext.SaveChanges();
            return result;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            T result = _dbSet.Update(entity).Entity;
            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
