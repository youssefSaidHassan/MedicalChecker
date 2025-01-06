using MedicalChecker.Data.Entities;
using MedicalChecker.Utility.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalChecker.Infrastructure.Configurations
{
    public class RequestConfigurations : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(x => x.Requests).HasForeignKey(x => x.UserId);
            builder.Property(x => x.Status).HasDefaultValue(RequestStatusEnum.Pending);
            builder.Property(x => x.FileName).HasMaxLength(100);
        }
    }
}
