namespace TeContrato.API.Domain.Services.Communications
{
    public abstract class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; protected set; }
        public T Resource { get; set; }

        public BaseResponse(T resource)
        {
            Resource = resource;
            Success = true;
            Message = string.Empty;
        }
        public BaseResponse(string message)
        {
            Success = false;
            Message = message;
        }
    }
}
