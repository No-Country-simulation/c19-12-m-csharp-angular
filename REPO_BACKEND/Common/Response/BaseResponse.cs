namespace backnc.Common.Response
{
    public class BaseResponse
    {
        public string status { get; set; } = "success";
        public string message { get; set; }
        public object data { get; set; }
		public bool IsSuccess { get; internal set; }

		public BaseResponse(){}
        public BaseResponse(object data)
        {
            this.data = data;
        }
        public BaseResponse(string message)
        { 
            this.message = message;
        }
        public BaseResponse(string message, object data, bool errorbandera)
        {
            if (errorbandera)
            {
                this.status = "error";
                this.message = message;
                this.data = data;
            }
            else
            {
                this.message = message;
                this.data = data;
            } 
        }
        //con validationError
        public BaseResponse(object errors, string message = "Erro de validación")
        {
            this.status = "error";
            this.message = message;
            this.data = errors;
        }
    }
    public static class Response
    {
        public static BaseResponse Success()
        {
            return new BaseResponse();
        }
        public static BaseResponse Success(object data)
        {
            return new BaseResponse(data);
        }
        public static BaseResponse Success(string mensage)
        {
            return new BaseResponse(mensage);
        }
        public static BaseResponse Success(string mensage,object data, bool errorbandera =false)
        {
            return new BaseResponse(mensage, data, errorbandera);
        }
        public static BaseResponse ValidationError( string mensage, object errors, bool errorbandera = true)
        {
            return new BaseResponse(mensage, errors, errorbandera);
        }
    }
}
