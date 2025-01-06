using MedicalChecker.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalChecker.Infrastructure.Configurations
{
    public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(80);
            builder.HasMany(x => x.Doctors).WithOne(x => x.Department).HasForeignKey(x => x.DId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
