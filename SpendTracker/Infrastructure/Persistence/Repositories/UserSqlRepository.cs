using Microsoft.EntityFrameworkCore;
using SpendTracker.Domain.Users;
using System.Collections.Immutable;
using System.Linq.Expressions;


namespace SpendTracker.Infrastructure.Persistence.Repositories
{
    public class UserSqlRepository: SqlRepository<User, Guid>, IUserRepository
    {
        public UserSqlRepository(UserContext context)
        : base(context) { }

       
         

        public override async Task<IReadOnlyList<User>> SearchAsync(string? text)
        {
            var query = _set.AsNoTracking();

            if (!string.IsNullOrEmpty(text))
            {
                query = query.Where(user =>
                    EF.Functions.Like(user.Name, $"%{text}%")
                    || EF.Functions.Like(user.UserName, $"%{text}%")
                );
            } 
            var result = await query.ToListAsync();

            return result.ToImmutableList();
        }

         
    }
}
