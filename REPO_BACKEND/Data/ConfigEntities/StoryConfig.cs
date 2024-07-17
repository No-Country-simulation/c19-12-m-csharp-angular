using backnc.Data.POCOEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backnc.Data.ConfigEntities
{
    public class StoryConfig : IEntityTypeConfiguration<Story>
    {
        public void Configure(EntityTypeBuilder<Story> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Title).IsRequired().HasMaxLength(255);
            builder.Property(s => s.Description).IsRequired().HasColumnType("TEXT");
            builder.Property(s => s.Image).HasMaxLength(255);

            // Relación con StoryList
            builder.HasOne(s => s.StoryList)
                   .WithMany(sl => sl.Stories)
                   .HasForeignKey(s => s.StoryListId);
        }
    }
}
