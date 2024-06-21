using Microsoft.EntityFrameworkCore;
using SpendTracker.Domain.Spends;


namespace SpendTracker.Infrastructure.Persistence
{
    public class SpendContext:DbContext
    {
        public SpendContext(DbContextOptions<SpendContext> options) :
          base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public DbSet<Spend> Spends => Set<Spend>();

    }
}
