using Microsoft.EntityFrameworkCore;

namespace backnc.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
		{

		}

	}
}
