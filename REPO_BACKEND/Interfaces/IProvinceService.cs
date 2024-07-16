using backnc.Common.DTOs.CountryDTOs;
using backnc.Common.DTOs.ProvinceDTO;
using backnc.Data.POCOEntities;

namespace backnc.Interfaces
{
	public interface IProvinceSerivce
	{
		Task<IEnumerable<Province>> GetAllProvinces();
		Task<Province> GetProvinceById(int id);
		Task<Province> AddProvince(CreateProvinceDTO createProvinceDTO);
		Task<Province> UpdateProvince(int id, EditProvinceDTO editProvinceDTO);
		Task<bool> DeleteProvince(int id);
	}
}
