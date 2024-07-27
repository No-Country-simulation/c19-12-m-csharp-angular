using backnc.Data.POCOEntities;

namespace backnc.Common.DTOs.ProfileDTO
{
	public class CreateProfileDTO
	{
		public string Specialty { get; set; }
		public string Experience { get; set; }
		public string Description { get; set; }
		public IFormFile Image { get; set; }

		//public List<int> Categories { get; set; }
		public List<Category> Categories { get; set; }



	}
}
