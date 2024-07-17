using backnc.Data.POCOEntities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backnc.Data.ConfigEntities
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(255);

            // Relación con JobType
            builder.HasMany(c => c.JobTypes)
                   .WithOne(jt => jt.Category)
                   .HasForeignKey(jt => jt.CategoryId);
        }
    }
}
