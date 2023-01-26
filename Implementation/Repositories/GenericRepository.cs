using System.Linq.Expressions;
using Backend.Context;
using Backend.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Implementation.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationContext _context;
        public GenericRepository(ApplicationContext context) => (_context) = (context);
        public async Task<T> Add(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
           await _context.SaveChangesAsync();
           return entity;
        }

        public async Task<bool> Delete(T entity)
        {
             _context.Set<T>().Remove(entity);
           await _context.SaveChangesAsync();
           return true;
        }

        public async Task<bool> Exist(Expression<Func<T, bool>> expression)
        {
            var entity = await _context.Set<T>().AnyAsync(expression);
            return entity;
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
            var entity = await _context.Set<T>().SingleOrDefaultAsync(expression);
            return entity;
        }

        public async Task<IReadOnlyList<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            var entity = await _context.Set<T>().Where(expression).ToListAsync();
            return entity;
        }
    }
}