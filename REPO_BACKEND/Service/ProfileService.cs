using backnc.Data.Interface;
using backnc.Data.POCOEntities;
using Microsoft.EntityFrameworkCore;

namespace backnc.Service
{
	public class ProfileService
	{
		private readonly IAppDbContext context;
        public ProfileService(IAppDbContext context)
        {
            this.context = context;
        }
		public async Task<Profile> GetProfileByUser(int userId)
		{
			return await context.Profiles
				.FirstOrDefaultAsync(p => p.UserId == userId);
		}

		public async Task<Profile> CreateProfile(Profile profile)
		{
			context.Profiles.Add(profile);
			await context.SaveChangesAsync();
			return profile;
		}

		public async Task<Profile> UpdateProfile(Profile profile)
		{
			context.Profiles.Update(profile);
			await context.SaveChangesAsync();
			return profile;
		}

	}
}
