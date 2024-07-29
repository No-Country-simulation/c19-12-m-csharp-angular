using backnc.Common.DTOs.CategoryDTO;

namespace backnc.Common.DTOs.ProfileDTO
{
	public class ProfileDTO
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Specialty { get; set; }
		public string Experience { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public List<CategoryDTO> Categories { get; set; }

	}

	
}
