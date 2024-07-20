using backnc.Common.Response;
using backnc.Interfaces;
using backnc.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace backnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse>> Login(LoginUser userLogin)
        {
            return  await _userService.Authenticate(userLogin);
        }
        
        [HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterUser registerUser)
		{
        var result = await _userService.Register(registerUser);
        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

			return Ok(result);
		 }
		[HttpPost("validate-token")]
		public async Task<IActionResult> ValidateToken([FromBody] string token)
		{
			var response = await _userService.ValidateToken(token);

			if (!response.IsSuccess)
			{
				return BadRequest(response);
			}

			return Ok(response);
		}

		[HttpGet("validate-token")]
		public async Task<IActionResult> ValidateToken()
		{
			if (!Request.Headers.ContainsKey("Authorization"))
			{
				return BadRequest(new { message = "El encabezado de autorización no está presente." });
			}

			var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

			var response = await _userService.ValidateToken(token);

			if (!response.IsSuccess)
			{
				return BadRequest(response);
			}

			return Ok(response);
		}

		  #region
//		using backnc.Common.Response;
//using backnc.Interfaces;
//using backnc.Models;
//using Microsoft.AspNetCore.Mvc;
//using Swashbuckle.AspNetCore.Annotations;
//using System.Net;

//namespace backnc.Controllers
//	{
//		[Route("api/[controller]")]
//		[ApiController]
//		public class LoginController : ControllerBase
//		{
//			private readonly IUserService _userService;

//			public LoginController(IUserService userService)
//			{
//				_userService = userService;
//			}

//			/// <summary>
//			/// Autentica un usuario.
//			/// </summary>
//			/// <param name="userLogin">Los datos de inicio de sesión del usuario.</param>
//			/// <returns>Un token JWT si las credenciales son correctas.</returns>
//			/// <response code="200">Retorna el token JWT.</response>
//			/// <response code="400">Si las credenciales son incorrectas.</response>
//			[HttpPost]
//			[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
//			[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.BadRequest)]
//			[SwaggerResponse(200, "Success", typeof(BaseResponse))]
//			[SwaggerResponse(400, "Bad Request", typeof(BaseResponse))]
//			public async Task<ActionResult<BaseResponse>> Login(LoginUser userLogin)
//			{
//				var result = await _userService.Authenticate(userLogin);
//				if (!result.IsSuccess)
//				{
//					return BadRequest(result);
//				}
//				return Ok(result);
//			}

//			/// <summary>
//			/// Registra un nuevo usuario.
//			/// </summary>
//			/// <param name="registerUser">Los datos del usuario a registrar.</param>
//			/// <returns>Un mensaje de éxito si el registro fue exitoso.</returns>
//			/// <response code="200">Si el usuario fue registrado exitosamente.</response>
//			/// <response code="400">Si hubo errores de validación.</response>
//			[HttpPost("register")]
//			[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
//			[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.BadRequest)]
//			[SwaggerResponse(200, "Success", typeof(BaseResponse))]
//			[SwaggerResponse(400, "Bad Request", typeof(BaseResponse))]
//			public async Task<IActionResult> Register([FromBody] RegisterUser registerUser)
//			{
//				var result = await _userService.Register(registerUser);
//				if (!result.IsSuccess)
//				{
//					return BadRequest(result);
//				}
//				return Ok(result);
//			}

//			/// <summary>
//			/// Valida un token JWT.
//			/// </summary>
//			/// <param name="token">El token JWT a validar.</param>
//			/// <returns>Información del usuario si el token es válido.</returns>
//			/// <response code="200">Retorna la información del usuario si el token es válido.</response>
//			/// <response code="400">Si el token es inválido o no está presente.</response>
//			[HttpPost("validate-token")]
//			[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
//			[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.BadRequest)]
//			[SwaggerResponse(200, "Success", typeof(BaseResponse))]
//			[SwaggerResponse(400, "Bad Request", typeof(BaseResponse))]
//			public async Task<IActionResult> ValidateToken([FromBody] string token)
//			{
//				var response = await _userService.ValidateToken(token);

//				if (!response.IsSuccess)
//				{
//					return BadRequest(response);
//				}

//				return Ok(response);
//			}

//			/// <summary>
//			/// Valida un token JWT desde el encabezado.
//			/// </summary>
//			/// <returns>Información del usuario si el token es válido.</returns>
//			/// <response code="200">Retorna la información del usuario si el token es válido.</response>
//			/// <response code="400">Si el token es inválido o no está presente.</response>
//			[HttpGet("validate-token")]
//			[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
//			[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.BadRequest)]
//			[SwaggerResponse(200, "Success", typeof(BaseResponse))]
//			[SwaggerResponse(400, "Bad Request", typeof(BaseResponse))]
//			public async Task<IActionResult> ValidateToken()
//			{
//				if (!Request.Headers.ContainsKey("Authorization"))
//				{
//					return BadRequest(new { message = "El encabezado de autorización no está presente." });
//				}

//				var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

//				var response = await _userService.ValidateToken(token);

//				if (!response.IsSuccess)
//				{
//					return BadRequest(response);
//				}

//				return Ok(response);
//			}
//		}
//	}


	#endregion
	}
}
