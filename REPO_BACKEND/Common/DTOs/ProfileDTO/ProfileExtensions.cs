using backnc.Common.DTOs.CategoryDTO;

namespace backnc.Common.DTOs.ProfileDTO
{
	public static class ProfileExtensions
	{
		public static CreateProfileDTO ToDto(this CreateProfileDTO profile)
		{
			return new CreateProfileDTO
			{								
				Specialty = profile.Specialty,
				Experience = profile.Experience,
				Description = profile.Description,
				
				Categories = profile.p.Select(pc => new CreateCategoryDTO
				{					
					Name = pc.Category.Name
				}).ToList()
			};
		}
	}
}
