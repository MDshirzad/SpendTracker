using Microsoft.EntityFrameworkCore;
using SpendTracker.Domain.Users;

namespace SpendTracker.Infrastructure.Persistence
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options):
            base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public DbSet<User> Users => Set<User>();

    }
}
