using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpendTracker.Domain.Journies;
using SpendTracker.Domain.Users;
using System.Reflection.Emit;

namespace SpendTracker.Infrastructure.Persistence.Configuration
{
    public class JourneyConfiguration : IEntityTypeConfiguration<Journey>
    {
        public void Configure(EntityTypeBuilder<Journey> builder)
        {
            builder.ToTable("Journeys");

            // Setting JourneyId as the primary key
            builder.HasKey(j => j.JourneyId);

            builder.Property(j => j.JourneyName).IsRequired().HasMaxLength(200);
            builder.Property(j => j.StartDate).IsRequired();
            builder.Property(j => j.EndDate).IsRequired();

            // Configuring the many-to-one relationship with User
            builder.HasOne(j => j.User)
                   .WithMany(u => u.Journeys)
                   .HasForeignKey(j => j.UserId);

            // Configuring the one-to-one relationship with JourneySpends
            builder.HasOne(j => j.JourneySpends)
                   .WithOne(js => js.Journey)
                   .HasForeignKey<JourneySpends>(js => js.JourneyId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
