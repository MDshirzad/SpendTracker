using Microsoft.EntityFrameworkCore;
using SpendTracker.Domain.Primitives;
using SpendTracker.Domain.Primitives.Contracts;
using System.Collections.Immutable;
using System.Linq.Expressions;

namespace SpendTracker.Infrastructure.Persistence.Repositories
{
    public abstract class SqlRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : notnull
    {

        private readonly DbContext _context;
        protected DbSet<TEntity> _set;
        protected SqlRepository(DbContext context) {
            _context = context;
            _set = _context.Set<TEntity>();
        
        }

        public async Task CreateAsync(TEntity entity)
        {
           await _set.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _set.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<IReadOnlyList<TEntity>> Filter(string? criteria)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await _set.Where(predicate).ToListAsync();

            return result.ToImmutableList();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            var result = await _set.AsNoTracking().ToListAsync();
            return result.ToImmutableList();

        }

        public async Task<TEntity?> GetByIdAsync(TId id) => await _set.FindAsync(id);


        public abstract Task<IReadOnlyList<TEntity>> SearchAsync(string? text );

        public async Task  UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
