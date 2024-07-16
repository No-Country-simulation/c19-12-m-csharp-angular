using backnc.Common.Response;
using backnc.Interfaces;
using backnc.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
