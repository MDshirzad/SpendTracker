namespace SpendTracker.Domain.Primitives.Contracts
{
    public interface IEntity<TId> where TId :  notnull
    {
        TId Id { get; }

    }
}
