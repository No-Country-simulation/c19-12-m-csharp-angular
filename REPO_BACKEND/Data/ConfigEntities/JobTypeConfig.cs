using backnc.Data.POCOEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backnc.Data.ConfigEntities
{
    public class JobTypeConfig : IEntityTypeConfiguration<JobType>
    {
        public void Configure(EntityTypeBuilder<JobType> builder)
        {
            builder.HasKey(jt => jt.Id);

            builder.Property(jt => jt.Name).IsRequired().HasMaxLength(255);

            builder.HasOne(jt => jt.Category)
                   .WithMany(c => c.JobTypes)
                   .HasForeignKey(jt => jt.CategoryId);

            // Relación con UserJobType
            builder.HasMany(jt => jt.UserJobTypes)
               .WithOne(ujt => ujt.JobType)
               .HasForeignKey(ujt => ujt.JobTypeId);
        }
    }
}
