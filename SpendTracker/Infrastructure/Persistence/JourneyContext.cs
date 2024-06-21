using Microsoft.EntityFrameworkCore;
using SpendTracker.Domain.Journies;
using SpendTracker.Domain.Users;

namespace SpendTracker.Infrastructure.Persistence
{
    public class JourneyContext:DbContext
    {


        public JourneyContext(DbContextOptions<JourneyContext> options) :
           base(options)
        { }

        public DbSet<Journey> Journeys => Set<Journey>();
        public DbSet<JourneySpends> JourneySpends => Set<JourneySpends>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }


    }
}
