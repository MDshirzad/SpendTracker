using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpendTracker.Domain.Spends;

namespace SpendTracker.Infrastructure.Persistence.Configuration
{
    public class SpendConfiguration : IEntityTypeConfiguration<Spend>
    {
        public void Configure(EntityTypeBuilder<Spend> builder)
        {
            builder.ToTable("Spends");

            // Setting SpendId as the primary key
            builder.HasKey(s => s.SpendId);

            builder.Property(s => s.SpendDate).IsRequired();
            builder.Property(s => s.Amount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");
            builder.Property(s => s.Category)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(s => s.Description)
                   .HasMaxLength(500);
        }
    }
}
