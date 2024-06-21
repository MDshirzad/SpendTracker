using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpendTracker.Domain.Journies;
using System.Reflection.Emit;

namespace SpendTracker.Infrastructure.Persistence.Configuration
{
    public class JourneySpendsConfiguration : IEntityTypeConfiguration<JourneySpends>
    {
        public void Configure(EntityTypeBuilder<JourneySpends> builder)
        {
            builder.ToTable("JourneySpends");

            // Setting JourneySpendsId as the primary key
            builder.HasKey(js => js.JourneySpendsId);

            builder.Property(js => js.TotalAmount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");
            builder.Property(js => js.Currency)
                   .IsRequired()
                   .HasMaxLength(3);

            // Configuring the one-to-one relationship with Journey
            builder.HasOne(js => js.Journey)
                   .WithOne(j => j.JourneySpends)
                   .HasForeignKey<JourneySpends>(js => js.JourneyId)
                   .OnDelete(DeleteBehavior.Cascade); // Ensure cascading delete to prevent orphaned records

            // Configuring the one-to-many relationship with Spend
            builder.HasMany(js => js.Spends)
                   .WithOne(s => s.JourneySpends)
                   .HasForeignKey(s => s.JourneySpendsId);
        }
    }
}
