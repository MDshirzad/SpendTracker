using SpendTracker.Domain.Primitives.Contracts;

namespace SpendTracker.Domain.Users
{
    public interface IUserRepository:IRepository<User,Guid>
    {
    }
}
