using System.Linq.Expressions;

namespace SpendTracker.Domain.Primitives.Contracts
{
    public interface IRepository<TEntity,TId> where TEntity : IEntity<TId> where TId : notnull
    {

        Task<TEntity> GetByIdAsync(TId id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task DeleteAsync(TEntity entity );
        Task  UpdateAsync(TEntity entity);
        Task CreateAsync(TEntity entity);
        Task<IReadOnlyList<TEntity?>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IReadOnlyList<TEntity>> Filter(string? criteria);
        Task<IReadOnlyList<TEntity>> SearchAsync(string? text);
    }
}
