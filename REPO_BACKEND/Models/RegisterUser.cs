namespace backnc.Models
{
	public class RegisterUser
	{
		public string userName { get; set; }		
		public string firstName {  get; set; }
		public string lastName { get; set; }
		public string email { get; set; }
		public string dni { get; set; }
		public string phoneNumber { get; set; }
		public string password { get; set; }
		public string address { get; set; }
		public int CountryId { get; set; }
		public int ProvinceId { get; set; }
		public int NeighborhoodId { get; set; }


	}
}
