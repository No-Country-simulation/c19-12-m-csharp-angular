using backnc.Data.POCOEntities;
using Microsoft.EntityFrameworkCore;

namespace backnc.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
		{

		}
		public DbSet<TodoTest> todoTests { get; set; }
	}
}
