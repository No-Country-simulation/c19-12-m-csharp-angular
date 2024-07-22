using backnc.Common;
using backnc.Data.Context;
using backnc.Data.POCOEntities;
using Microsoft.EntityFrameworkCore;

public class DataSeeder
{
	private readonly AppDbContext _context;

	public DataSeeder(AppDbContext context)
	{
		_context = context;
	}

	public async Task SeedAsync()
	{
		await CreateRolesAsync();
		await CreateAdminUserAsync();
		await CreateClienteAsync();
	}

	private async Task CreateRolesAsync()
	{
		if (await _context.Roles.AnyAsync()) return;

		var roles = new[]
		{
			new Role { Name = "Admin" },
			new Role { Name = "Cliente" }
		};

		await _context.Roles.AddRangeAsync(roles);
		await _context.SaveChangesAsync();
	}

	private async Task CreateAdminUserAsync()
	{
		if (await _context.Users.AnyAsync(u => u.UserName == "admin")) return;

		var adminRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Admin");
		if (adminRole == null) throw new Exception("Role 'Admin' does not exist.");

		var newUser = new User
		{
			UserName = "admin",
			firstName = "Administrador",
			lastName = "Administrador",
			email = "admin@gmail.com",
			Password = PasswordHasher.HashPassword("Admin123!")
		};

		_context.Users.Add(newUser);
		await _context.SaveChangesAsync();

		var userRole = new UserRole
		{
			UserId = newUser.Id,
			RoleId = adminRole.Id
		};

		_context.UserRoles.Add(userRole);
		await _context.SaveChangesAsync();
	}
	private async Task CreateClienteAsync()
	{
		if (await _context.Users.AnyAsync(u => u.UserName == "cliente")) return;

		var adminRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Cliente");
		if (adminRole == null) throw new Exception("Role 'Cliente' does not exist.");

		var newUser = new User
		{
			UserName = "cliente",
			firstName = "cliente",
			lastName = "cliente",
			email = "cliente@gmail.com",
			Password = PasswordHasher.HashPassword("Cliente123!")
		};

		_context.Users.Add(newUser);
		await _context.SaveChangesAsync();

		var userRole = new UserRole
		{
			UserId = newUser.Id,
			RoleId = adminRole.Id
		};

		_context.UserRoles.Add(userRole);
		await _context.SaveChangesAsync();
	}
}
