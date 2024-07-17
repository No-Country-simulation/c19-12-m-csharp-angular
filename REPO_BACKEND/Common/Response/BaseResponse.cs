using Newtonsoft.Json;

namespace backnc.Common.Response
{
    public class BaseResponse
    {
        public CodeStatus? status { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string message { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object data { get; set; }
		
        BaseResponse() { }
        //error o ok sin cuerpo
        public BaseResponse(CodeStatus status)
        {
            this.status = status;
        }
        //error o ok con mensage
        public BaseResponse(CodeStatus status,string message)
        {
            this.status = status;
            this.message = message;
        }
        //error o ok con mensage y cuerpo
        public BaseResponse(CodeStatus status, string message,object data)
        {
            this.status = status;
            this.message = message;
            this.data = data;
        }
    }
    public static class Response
    {
        //OK
        public static BaseResponse Success()
        {
            return new BaseResponse(CodeStatus.Ok);
        }
        public static BaseResponse Success(string mensage)
        {
            return new BaseResponse(CodeStatus.Ok, mensage);
        }
        public static BaseResponse Success(string mensage, object data)
        {
            return new BaseResponse(CodeStatus.Ok, mensage, data);
        }
        //CREATED
        public static BaseResponse Created()
        {
            return new BaseResponse(CodeStatus.Created);
        }
        public static BaseResponse Created(string mensage)
        {
            return new BaseResponse(CodeStatus.Created,mensage);
        }
        public static BaseResponse Created(string mensage,object data)
        {
            return new BaseResponse(CodeStatus.Created, mensage, data);
        }
        //validation Error
        public static BaseResponse ValidationError(string mensage,object data)
        {
            return new BaseResponse(CodeStatus.ValidationError, mensage, data);
        }
        public static BaseResponse InternalServer(string mensage="Ocurrio un error interno en el servidor, por favor, intentelo nuevamente más tarde.")
        {
            return new BaseResponse(CodeStatus.InternalServerError, mensage);
        }



    }

    public enum CodeStatus
    {
        Ok=200,
        Created=201,
        ValidationError=400,//bad request
        InternalServerError=500
       
    }
}
