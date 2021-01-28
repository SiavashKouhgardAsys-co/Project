using Microsoft.EntityFrameworkCore;
using MoshaverAmlak.DataLayer.Entity;

namespace MoshaverAmlak.DataLayer.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // GET DATE

        // CREATE

        // UPDATE

        // DELETE

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
