namespace backnc.Data.POCOEntities
{
	public class Job
	{
		public int Id { get; set; }
		public int ProfileId { get; set; }
		public int UserId { get; set; }  // Agrega esta línea
		public string Title { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public DateTime CreatedAt { get; set; }

		// Relación muchos a uno con Usuario
		public Profile Profile { get; set; }

	}
}
