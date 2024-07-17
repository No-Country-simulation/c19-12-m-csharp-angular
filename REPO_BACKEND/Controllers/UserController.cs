using backnc.Common.ExtensionsMethod;
using backnc.Common.Response;
using backnc.Interfaces;
using backnc.Models;
using Microsoft.AspNetCore.Mvc;

namespace backnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<BaseResponse>> Login(LoginUser userLogin)
        {
            return await _userService.Authenticate(userLogin);
        }
        
        [HttpPost("Register")]
        public async Task<ActionResult<BaseResponse>> Register([FromBody] RegisterUser registerUser)
        {
            return (await _userService.Register(registerUser)).ToResult();
        }
    }
}
