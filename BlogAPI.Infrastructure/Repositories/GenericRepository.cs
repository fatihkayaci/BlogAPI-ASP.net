using BlogAPI.Domain.Entities;
using BlogAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace BlogAPI.Application.Interfaces
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BlogDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(BlogDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            List<T> entities = await _dbSet.ToListAsync();
            return entities;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            
            var entity = await _dbSet.FindAsync(id);
            return entity;            
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}