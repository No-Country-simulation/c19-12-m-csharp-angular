﻿namespace backnc.Common.DTOs.JobDTO
{
	public class CreateJobDTO
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public IFormFile Image { get; set; }
	}
}
