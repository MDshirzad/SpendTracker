using CSharpFunctionalExtensions;
using SpendTracker.Domain.Primitives.Contracts;

namespace SpendTracker.Domain.Primitives
{
    public abstract class Entity<TId> : IEntity<TId>
    {

        public TId Id { get; init; }

        public Entity(TId id)
        {
            Id = id;
        }
    }
}
