using backnc.Common.Response;
using backnc.Models;
using backnc.Service;
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
    }
}
