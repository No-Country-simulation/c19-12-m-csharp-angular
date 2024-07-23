using backnc.Data.POCOEntities;
using backnc.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backnc.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProfileController : ControllerBase
	{
		private readonly ProfileService _profileService;

		public ProfileController(ProfileService profileService)
		{
			_profileService = profileService;
		}

		[HttpGet("{userId}")]
		public async Task<IActionResult> GetProfileByUser(int userId)
		{
			var profile = await _profileService.GetProfileByUser(userId);
			return Ok(profile);
		}

		[HttpPost]
		public async Task<IActionResult> CreateProfile([FromBody] Profile profile)
		{
			var newProfile = await _profileService.CreateProfile(profile);
			return CreatedAtAction(nameof(GetProfileByUser), new { userId = newProfile.UserId }, newProfile);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProfile(int id, [FromBody] Profile profile)
		{
			if (id != profile.Id)
			{
				return BadRequest();
			}

			var updatedProfile = await _profileService.UpdateProfile(profile);
			return Ok(updatedProfile);
		}
	}
}
