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
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
