using backnc.Common.DTOs.AdministradorDTO;
using backnc.Data.POCOEntities;
using backnc.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backnc.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdministradorController : ControllerBase
	{
		private readonly AdministradorService _administradorService;
        public AdministradorController(AdministradorService administradorService)
        {
			this._administradorService = administradorService;         
        }

		[HttpGet]
		public async Task<IActionResult> GetAllAdmins()
		{
			var clientes = await _administradorService.GetAllAdminsAsync();
			return Ok(clientes);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAdminById(int id)
		{
			var cliente = await _administradorService.GetAdminByIdAsync(id);
			if (cliente == null)
			{
				return NotFound("Cliente no encontrado");
			}
			return Ok(cliente);
		}

		[HttpPost]
		public async Task<IActionResult> CreateAdmin(User user)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await _administradorService.CreateAdminAsync(user);
			return CreatedAtAction(nameof(GetAdminById), new { id = user.Id }, user);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAdmin(int id, User user)
		{
			if (id != user.Id)
			{
				return BadRequest("El ID del cliente no coincide");
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var existingCliente = await _administradorService.GetAdminByIdAsync(id);
			if (existingCliente == null)
			{
				return NotFound("Cliente no encontrado");
			}

			await _administradorService.UpdateAdminAsync(user);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAdmin(int id)
		{
			var cliente = await _administradorService.GetAdminByIdAsync(id);
			if (cliente == null)
			{
				return NotFound("Cliente no encontrado");
			}

			await _administradorService.DeleteAdminAsync(id);
			return NoContent();
		}
	}
}
