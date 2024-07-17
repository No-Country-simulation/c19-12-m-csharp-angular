using backnc.Data.POCOEntities;
using Microsoft.EntityFrameworkCore;

namespace backnc.Data.Interface
{
    public interface IAppDbContext : IDisposable
    {
        DbSet<User> Users { get; }
        DbSet<Role> Roles { get; }
        DbSet<UserRole> UserRoles { get; }
        DbSet<TodoTest> TodoTests { get; }
		DbSet<Country> Countries { get; set; }
		DbSet<Province> Provinces { get; set; }
		DbSet<Neighborhood> Neighborhoods { get; set; }

        DbSet<Category> Categories { get; set; }
        DbSet<JobType> JobTypes { get; set; }
        DbSet<UserJobType> UserJobTypes { get; set; }
        DbSet<StoryList> StoryLists { get; set; }
        DbSet<Story> Stories { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
