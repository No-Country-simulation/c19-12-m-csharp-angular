using backnc.Common.Response;
using backnc.Models;
using Microsoft.AspNetCore.Mvc;

namespace backnc.Service
{
    public interface IUserService
    {
        Task<BaseResponse> Authenticate(LoginUser userLogin);
    }
}
