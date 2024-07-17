using backnc.Data.POCOEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backnc.Data.ConfigEntities
{
    public class StoryListConfig : IEntityTypeConfiguration<StoryList>
    {
        public void Configure(EntityTypeBuilder<StoryList> builder)
        {
            builder.HasKey(sl => sl.Id);
            builder.Property(sl => sl.Name).IsRequired().HasMaxLength(255);

            // Relación con UserJobType
            builder.HasOne(sl => sl.UserJobType)
                   .WithMany(ujt => ujt.StoryLists)
                   .HasForeignKey(sl => sl.UserJobTypeId);

            // Relación con Story
            builder.HasMany(sl => sl.Stories)
                   .WithOne(s => s.StoryList)
                   .HasForeignKey(s => s.StoryListId);
        }
    }
}
