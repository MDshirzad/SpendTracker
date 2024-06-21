using Microsoft.EntityFrameworkCore;
using SpendTracker.Domain.Journies;
using SpendTracker.Domain.Spends;
using SpendTracker.Domain.Users;

namespace SpendTracker.Infrastructure.Persistence
{
    public class JourneySpendsContext:DbContext
    {

        public JourneySpendsContext(DbContextOptions<JourneySpendsContext> options) :
            base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JourneySpendsContext).Assembly);
        }
        public DbSet<JourneySpends> JourneySpends => Set<JourneySpends>();

      
        public DbSet<Spend> Spends => Set<Spend>();

    }
}
