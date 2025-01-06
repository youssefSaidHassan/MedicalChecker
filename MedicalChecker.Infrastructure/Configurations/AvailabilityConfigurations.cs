using MedicalChecker.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalChecker.Infrastructure.Configurations
{
    public class AvailabilityConfigurations : IEntityTypeConfiguration<Availability>
    {
        public void Configure(EntityTypeBuilder<Availability> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StartTime)
                .IsRequired()
                .HasConversion(
                    v => v.ToTimeSpan(), // Convert TimeOnly to TimeSpan for storage
                    v => TimeOnly.FromTimeSpan(v) // Convert TimeSpan back to TimeOnly
                );
            builder.Property(x => x.EndTime)
                .IsRequired()
                .HasConversion(
                    v => v.ToTimeSpan(), // Convert TimeOnly to TimeSpan for storage
                    v => TimeOnly.FromTimeSpan(v) // Convert TimeSpan back to TimeOnly
                );
            builder.Property(x => x.BreakAfterHours).IsRequired();
            builder.Property(x => x.BreakDuration)
                .IsRequired()
                .HasConversion(
                    v => v.ToTimeSpan(), // Convert TimeOnly to TimeSpan for storage
                    v => TimeOnly.FromTimeSpan(v) // Convert TimeSpan back to TimeOnly
                );
            builder.Property(x => x.Day).IsRequired();
            builder.Property(x => x.DoctorId).IsRequired();
            builder.HasOne(x => x.Doctor).WithMany(x => x.Availabilities).HasForeignKey(x => x.DoctorId);

        }
    }
}
