using backnc.Common.DTOs.NeighborhoodDTO;
using backnc.Data.POCOEntities;
using Microsoft.EntityFrameworkCore;

namespace backnc.Service
{
	public class NeighborhoodService
	{
		//private readonly DbContext _context;

		//public NeighborhoodService(DbContext context)
		//{
		//	_context = context;
		//}

		//public async Task<List<Neighborhood>> GetNeighborhoodsByProvinceId(int provinceId)
		//{
		//	return await _context.Neighborhoods.Where(n => n.ProvinceId == provinceId).ToListAsync();
		//}

		//public async Task<Neighborhood> AddNeighborhood(CreateNeighborhoodDTO createNeighborhoodDTO)
		//{
		//	var neighborhood = new Neighborhood { Name = createNeighborhoodDTO.Name, ProvinceId = createNeighborhoodDTO.ProvinceId };
		//	_context.Neighborhoods.Add(neighborhood);
		//	await _context.SaveChangesAsync();
		//	return neighborhood;
		//}
	}
}
