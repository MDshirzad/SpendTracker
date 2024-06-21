using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpendTracker.Domain.Users;
using System.Reflection.Emit;

namespace SpendTracker.Infrastructure.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable("Users");

            // Setting UserId as the primary key
            builder.HasKey(x => x.UserId);

            // Ensuring that the Name and UserName properties are required
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.UserName).IsRequired();

            // Configuring the one-to-many relationship with Journey
            builder.HasMany(u => u.Journeys)
                   .WithOne(j => j.User)
                   .HasForeignKey(j => j.UserId);

        }
    }
}
