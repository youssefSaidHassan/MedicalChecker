using MedicalChecker.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalChecker.Infrastructure.Configurations
{
    public class PrecautionsConfigurations : IEntityTypeConfiguration<Precautions>
    {
        public void Configure(EntityTypeBuilder<Precautions> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired();
            builder.HasMany(x => x.DiseasePrecautions).WithOne(x => x.Precaution).HasForeignKey(x => x.PrecautionId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
