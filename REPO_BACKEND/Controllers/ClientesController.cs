using backnc.Common.Response;
using backnc.Data.POCOEntities;
using backnc.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backnc.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClientesController : ControllerBase
	{
        private readonly ClienteService _clienteService;
        public ClientesController(ClienteService _clienteService)
        {
            this._clienteService = _clienteService;
        }


		[HttpGet]
		public async Task<IActionResult> GetAllClientes()
		{
			var clientes = await _clienteService.GetAllClientesAsync();
			return Ok(clientes);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetClienteById(int id)
		{
			var cliente = await _clienteService.GetClienteByIdAsync(id);
			if (cliente == null)
			{
				return NotFound("Cliente no encontrado");
			}
			return Ok(cliente);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCliente(User user)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await _clienteService.CreateClienteAsync(user);
			return CreatedAtAction(nameof(GetClienteById), new { id = user.Id }, user);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCliente(int id, User user)
		{
			if (id != user.Id)
			{
				return BadRequest("El ID del cliente no coincide");
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var existingCliente = await _clienteService.GetClienteByIdAsync(id);
			if (existingCliente == null)
			{
				return NotFound("Cliente no encontrado");
			}

			await _clienteService.UpdateClienteAsync(user);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCliente(int id)
		{
			var cliente = await _clienteService.GetClienteByIdAsync(id);
			if (cliente == null)
			{
				return NotFound("Cliente no encontrado");
			}

			await _clienteService.DeleteClienteAsync(id);
			return NoContent();
		}
	}
}
