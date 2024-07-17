using backnc.Data.POCOEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backnc.Data.ConfigEntities
{
    public class UserJobTypeConfig : IEntityTypeConfiguration<UserJobType>
    {
        public void Configure(EntityTypeBuilder<UserJobType> builder)
        {
            builder.HasKey(ujt => ujt.Id);

            // Relación con User
            builder.HasOne(ujt => ujt.User)
                   .WithMany(u => u.UserJobTypes)
                   .HasForeignKey(ujt => ujt.UserId);

            // Relación con JobType
            builder.HasOne(ujt => ujt.JobType)
                   .WithMany(jt => jt.UserJobTypes)
                   .HasForeignKey(ujt => ujt.JobTypeId);
        }
    }
}
