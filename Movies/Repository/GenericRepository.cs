using Microsoft.EntityFrameworkCore;
using Movies.contract;
using Movies.Data;

namespace Movies.Repository
{
    public class GenericRepository<T> : IGenericRespository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            this._context = context;  
        }

        public async Task<T> AddAsync(T Entity)
        {
            await _context.Set<T>().AddAsync(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var data = await GetAsync(id);
            _context.Set<T>().Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T Entity)
        {
            _context.Update(Entity);
            await _context.SaveChangesAsync();
        }
    }
}
