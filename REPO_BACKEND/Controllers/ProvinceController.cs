//using backnc.Common.DTOs.ProvinceDTO;
//using backnc.Interfaces;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace backnc.Controllers
//{
//	[Route("api/[controller]")]
//	[ApiController]
//	public class ProvinceController : ControllerBase
//	{
//		private readonly IProvinceSerivce _provinceService;

//		public ProvinceController(IProvinceSerivce provinceService)
//		{
//			_provinceService = provinceService;
//		}

//		[HttpGet]
//		public async Task<IActionResult> GetAllProvinces()
//		{
//			var provinces = await _provinceService.GetAllProvinces();
//			return Ok(provinces);
//		}

//		[HttpGet("{id}")]
//		public async Task<IActionResult> GetProvinceById(int id)
//		{
//			var province = await _provinceService.GetProvinceById(id);
//			if (province == null)
//			{
//				return NotFound();
//			}
//			return Ok(province);
//		}

//		[HttpPost]
//		public async Task<IActionResult> AddProvince([FromBody] CreateProvinceDTO createProvinceDTO)
//		{
//			try
//			{
//				var newProvince = await _provinceService.AddProvince(createProvinceDTO);
//				return CreatedAtAction(nameof(GetProvinceById), new { id = newProvince.Id }, newProvince);
//			}
//			catch (Exception ex)
//			{
//				return BadRequest(new { message = ex.Message });
//			}
//		}


//		[HttpPut("{id}")]
//		public async Task<IActionResult> UpdateProvince(int id, [FromBody] EditProvinceDTO editProvinceDTO)
//		{
//			var updatedProvince = await _provinceService.UpdateProvince(id, editProvinceDTO);
//			if (updatedProvince == null)
//			{
//				return NotFound();
//			}
//			return Ok(updatedProvince);
//		}

//		[HttpDelete("{id}")]
//		public async Task<IActionResult> DeleteProvince(int id)
//		{
//			var result = await _provinceService.DeleteProvince(id);
//			if (!result)
//			{
//				return NotFound();
//			}
//			return NoContent();
//		}
//	}
//}
