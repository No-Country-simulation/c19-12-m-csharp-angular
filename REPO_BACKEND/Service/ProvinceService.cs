using backnc.Common.DTOs.ProvinceDTO;
using backnc.Data.Interface;
using backnc.Data.POCOEntities;
using backnc.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backnc.Service
{
	public class ProvinceService :  IProvinceSerivce
	{
		private readonly IAppDbContext _context;

		public ProvinceService(IAppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Province>> GetAllProvinces()
		{
			return await _context.Provinces.ToListAsync();
		}

		public async Task<Province> GetProvinceById(int id)
		{
			return await _context.Provinces.FindAsync(id);
		}

		public async Task<Province> AddProvince(CreateProvinceDTO createProvinceDTO)
		{
			// Verificar si el CountryId proporcionado es válido
			var country = await _context.Countries.FindAsync(createProvinceDTO.CountryId);
			if (country == null)
			{
				throw new Exception("CountryId inválido");
			}

			var province = new Province
			{
				Name = createProvinceDTO.name,
				CountryId = createProvinceDTO.CountryId
			};

			_context.Provinces.Add(province);
			await _context.SaveChangesAsync();
			return province;
		}

		public async Task<Province> UpdateProvince(int id, EditProvinceDTO updateProvinceDTO)
		{
			var province = await _context.Provinces.FindAsync(id);
			if (province == null)
			{
				return null;
			}

			province.Name = updateProvinceDTO.name;
			await _context.SaveChangesAsync();
			return province;
		}

		public async Task<bool> DeleteProvince(int id)
		{
			var province = await _context.Provinces.FindAsync(id);
			if (province == null)
			{
				return false;
			}

			_context.Provinces.Remove(province);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
