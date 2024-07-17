using backnc.Common.Response;
using Microsoft.AspNetCore.Mvc;

namespace backnc.Common.ExtensionsMethod
{
    public static class BaseResultExtensions
    {
        public static ActionResult<BaseResponse> ToResult(this BaseResponse response)
        {
           
            if (response == null)
            {
                return new BadRequestResult(); 
            }

            
            var statusCode = response.status; 
            var objectResult = new ObjectResult(response)
            {
                StatusCode = ((int)statusCode.Value)
            };

            return objectResult;
        }
    }
}
