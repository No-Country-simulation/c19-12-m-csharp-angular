using backnc.Common.DTOs.CountryDTOs;
using backnc.Common.DTOs.NeighborhoodDTO;
using backnc.Interfaces;
using backnc.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backnc.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NeighborhoodController : ControllerBase
	{
		private readonly INeighborhoodService neighborhoodService;

        public NeighborhoodController(INeighborhoodService neighborhoodService)
        {
			this.neighborhoodService = neighborhoodService;
        }

		[HttpGet]
		public async Task<IActionResult> GetAllNeighborhoods()
		{
			var countries = await neighborhoodService.GetAllNeighborhoods();
			return Ok(countries);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetNeighborhoodById(int id)
		{
			var country = await neighborhoodService.GetNeighborhoodById(id);
			if (country == null)
			{
				return NotFound();
			}
			return Ok(country);
		}

		[HttpPost]
		public async Task<IActionResult> AddNeighborhood([FromBody] CreateNeighborhoodDTO createNeighborhoodDTO)
		{
			var newCountry = await neighborhoodService.AddNeighborhood(createNeighborhoodDTO);
			
			return Ok(newCountry);
		}
	}
}
