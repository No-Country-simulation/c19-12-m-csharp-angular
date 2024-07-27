using backnc.Common.DTOs.ProfileDTO;
using backnc.Common.Response;
using backnc.Data.Context;
using backnc.Data.POCOEntities;
using backnc.Interfaces;
using backnc.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace backnc.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProfileController : ControllerBase
	{
		private readonly ProfileService _profileService;
		private readonly AppDbContext _context;

		public ProfileController(ProfileService profileService, AppDbContext context)
		{
			_profileService = profileService;
			_context = context;
		}

		[HttpGet("{userId}")]
		public async Task<IActionResult> GetProfileByUser(int userId)
		{
			try
			{
				var profile = await _profileService.GetProfileByUser(userId);
				if (profile == null)
				{
					return NotFound(new BaseResponse("Perfil no encontrado."));
				}
				return Ok(new BaseResponse(profile));
			}
			catch (Exception ex)
			{
				return StatusCode(500, new BaseResponse("Error al obtener el perfil.", ex.Message, true));
			}
		}

		[Authorize]
		[HttpPut]
		public async Task<IActionResult> UpdateProfile([FromForm] CreateProfileDTO createProfileDTO)
		{
			var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
			var profile = await _profileService.GetProfileByUser(userId);

			if (profile == null)
			{
				return NotFound(new BaseResponse("Perfil no encontrado."));
			}

			profile.Specialty = createProfileDTO.Specialty;
			profile.Experience = createProfileDTO.Experience;
			profile.Description = createProfileDTO.Description;

			if (createProfileDTO.Image != null)
			{
				try
				{
					var imageUrl = await _profileService.SaveImageAsync(createProfileDTO.Image);
					profile.ImageUrl = imageUrl;
				}
				catch (Exception ex)
				{
					return StatusCode(500, new BaseResponse("Error al guardar la imagen.", ex.Message, true));
				}
			}

			try
			{
				await _profileService.UpdateProfile(profile);
				return Ok(new BaseResponse("Perfil actualizado correctamente."));
			}
			catch (Exception ex)
			{
				return StatusCode(500, new BaseResponse("Error al actualizar el perfil.", ex.Message, true));
			}
		}

		[HttpGet("CurrentUserProfile")]
		[Authorize]
		public async Task<IActionResult> GetCurrentUserProfile()
		{
			try
			{
				var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
				var profile = await _profileService.GetProfileByUser(userId);
				if (profile == null)
				{
					return NotFound(new BaseResponse("Perfil no encontrado."));
				}
				return Ok(new BaseResponse(profile));
			}
			catch (Exception ex)
			{
				return StatusCode(500, new BaseResponse("Error al obtener el perfil.", ex.Message, true));
			}
		}

		[HttpGet("ByUserId/{userId}")]
		[Authorize]
		public async Task<IActionResult> GetProfileByUserId(int userId)
		{
			try
			{
				var profile = await _profileService.GetProfileByUser(userId);
				if (profile == null)
				{
					return NotFound(new BaseResponse("Perfil no encontrado."));
				}
				return Ok(new BaseResponse(profile));
			}
			catch (Exception ex)
			{
				return StatusCode(500, new BaseResponse("Error al obtener el perfil.", ex.Message, true));
			}
		}

		[HttpGet("AllProfiles")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetAllProfiles()
		{
			try
			{
				var profiles = await _profileService.GetAllProfiles();
				return Ok(new BaseResponse(profiles));
			}
			catch (Exception ex)
			{
				return StatusCode(500, new BaseResponse("Error al obtener todos los perfiles.", ex.Message, true));
			}
		}
	}	
}
