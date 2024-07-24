using backnc.Data.Interface;
using backnc.Data.POCOEntities;
using backnc.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backnc.Service
{
	public class ProfileService 
	{
		private readonly IAppDbContext context;
		private readonly string rutaServidor;
		private readonly string rutaAlmacenamiento;
		public ProfileService(IAppDbContext context, IConfiguration configuration)
        {
            this.context = context;
			this.rutaAlmacenamiento = configuration["rutaImagenes"]!;
			this.rutaServidor = configuration["rutaServidor"]!;
		}
		public async Task<List<Profile>> GetAllProfiles()
		{
			return await context.Profiles.ToListAsync();
		}

		public async Task<Profile> GetProfileByUser(int userId)
		{
			return await context.Profiles.FirstOrDefaultAsync(p => p.UserId == userId);
		}

		//public async Task<Profile> CreateProfile(Profile profile)
		//{
		//	context.Profiles.Add(profile);
		//	await context.SaveChangesAsync();
		//	return profile;
		//}

		public async Task<Profile> UpdateProfile(Profile profile)
		{
			var existingProfile = await context.Profiles.FirstOrDefaultAsync(p => p.Id == profile.Id);

			if (existingProfile != null)
			{
				existingProfile.Specialty = profile.Specialty;
				existingProfile.Experience = profile.Experience;
				existingProfile.Description = profile.Description;
				existingProfile.ImageUrl = profile.ImageUrl;
				await context.SaveChangesAsync();
			}

			return existingProfile;
		}



		public async Task<string> SaveImageAsync(IFormFile image)
		{
			// Generar un nombre de archivo único
			string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
			// Ruta completa para almacenar la imagen
			string fullPath = Path.Combine(rutaAlmacenamiento, fileName);

			// Guardar la imagen en el sistema de archivos
			using (var stream = new FileStream(fullPath, FileMode.Create))
			{
				await image.CopyToAsync(stream);
			}
			// Devolver la URL relativa de la imagen
			return $"{rutaServidor}/images/{fileName}";
			
		}

	}
}
