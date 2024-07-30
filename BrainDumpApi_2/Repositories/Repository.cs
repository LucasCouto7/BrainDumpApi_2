using BrainDumpApi_2.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace BrainDumpApi_2.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly BrainDumpApiContext _context;

        public Repository(BrainDumpApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }
        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;

        }

        public T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return entity;
        }

    }
}
