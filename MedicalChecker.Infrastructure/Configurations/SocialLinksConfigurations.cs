using MedicalChecker.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalChecker.Infrastructure.Configurations
{
    public class SocialLinksConfigurations : IEntityTypeConfiguration<SocialLinks>
    {
        public void Configure(EntityTypeBuilder<SocialLinks> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(80);
            builder.Property(x => x.Url).IsRequired();
            builder.Property(x => x.DoctorId).IsRequired();
            builder.HasOne(x => x.Doctor).WithMany(x => x.SocialLinks).HasForeignKey(x => x.DoctorId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
