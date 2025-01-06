using MedicalChecker.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalChecker.Infrastructure.Configurations
{
    public class DiseaseConfigurations : IEntityTypeConfiguration<Disease>
    {
        public void Configure(EntityTypeBuilder<Disease> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.HasMany(x => x.DiseasePrecautions).WithOne(x => x.Disease).HasForeignKey(x => x.DiseaseId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
