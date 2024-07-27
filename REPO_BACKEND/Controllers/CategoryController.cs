using backnc.Common.DTOs.CategoryDTO;
using backnc.Common.Response;
using backnc.Data.Interface;
using backnc.Data.POCOEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backnc.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly IAppDbContext _context;

		public CategoryController(IAppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllCategories()
		{
			var categories = await _context.Categories.ToListAsync();
			return Ok(new BaseResponse(categories));
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]  // Restringir acceso solo a administradores
		public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO createCategoryDto)
		{
			if (createCategoryDto == null || string.IsNullOrWhiteSpace(createCategoryDto.Name))
			{
				return BadRequest(new BaseResponse("Invalid category data."));
			}

			var category = new Category
			{
				Name = createCategoryDto.Name
			};

			_context.Categories.Add(category);
			await _context.SaveChangesAsync();

			return Ok(new BaseResponse(category));
		}
	}
}
