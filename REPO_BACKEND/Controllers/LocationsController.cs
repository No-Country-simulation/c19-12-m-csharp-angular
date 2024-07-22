using backnc.Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backnc.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LocationsController : ControllerBase
	{

		private readonly IAppDbContext context;

        public LocationsController( IAppDbContext context)
        {
			this.context = context;
        }

		[HttpGet("countries")]
		public async Task<IActionResult> GetCountries()
		{
			var countries = await context.Countries.ToListAsync();
			return Ok(countries);
		}

		[HttpGet("provinces/{CountryId}")]
		public async Task<IActionResult> GetProvinces(int countryId)
		{
			var provinces = await context.Provinces.Where(p => p.CountryId == countryId).ToListAsync();
			return Ok(provinces);
		}

		[HttpGet("neighborhoods/{provinceId}")]
		public async Task<IActionResult> GetNeighborhoods(int provinceId)
		{
			var neighborhoods = await context.Neighborhoods.Where(n => n.ProvinceId == provinceId).ToListAsync();
			return Ok(neighborhoods);
		}
	}
}
