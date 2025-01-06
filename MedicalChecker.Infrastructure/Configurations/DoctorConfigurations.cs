using MedicalChecker.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalChecker.Infrastructure.Configurations
{
    public class DoctorConfigurations : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Bio).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.Street).IsRequired();
            builder.Property(x => x.State).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.ImagePath).HasDefaultValue("Images/No_Image.png");
            builder.Property(x => x.DId).IsRequired();
            builder.HasMany(x => x.Availabilities).WithOne(x => x.Doctor).HasForeignKey(x => x.DoctorId);
            builder.HasMany(x => x.SocialLinks).WithOne(x => x.Doctor).HasForeignKey(x => x.DoctorId);
            builder.HasOne(x => x.Department).WithMany(x => x.Doctors).HasForeignKey(x => x.DId);
            builder.HasOne(x => x.User).WithOne(x => x.Doctor).HasForeignKey<Doctor>(x => x.UserId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
