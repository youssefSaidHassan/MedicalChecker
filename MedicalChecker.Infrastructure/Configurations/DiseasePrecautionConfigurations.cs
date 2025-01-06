using MedicalChecker.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalChecker.Infrastructure.Configurations
{
    public class DiseasePrecautionConfigurations : IEntityTypeConfiguration<DiseasePrecaution>
    {
        public void Configure(EntityTypeBuilder<DiseasePrecaution> builder)
        {
            builder.HasKey(x => new { x.PrecautionId, x.DiseaseId });
            builder.HasOne(x => x.Disease).WithMany(x => x.DiseasePrecautions).HasForeignKey(x => x.DiseaseId);
            builder.HasOne(x => x.Precaution).WithMany(x => x.DiseasePrecautions).HasForeignKey(x => x.PrecautionId);
        }
    }
}
