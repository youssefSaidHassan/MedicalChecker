using MedicalChecker.Data.Entities;
using MedicalChecker.Utility.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalChecker.Infrastructure.Configurations
{
    public class AppointmentConfigurations : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).HasDefaultValue(AppointmentStatusEnum.Pending);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.DoctorId).IsRequired();
            builder.HasCheckConstraint("Date", "Date > GETDATE()");
            builder.HasOne(x => x.User).WithMany(x => x.Appointments).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Doctor).WithMany(x => x.Appointments).HasForeignKey(x => x.DoctorId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
