using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Services.Communications
{
    public class TTaskResponse : BaseResponse<TTask>
    {
        public TTaskResponse(TTask resource) : base(resource)
        {
            
        }

        public TTaskResponse(string message) : base(message)
        {
            
        }
    }
}