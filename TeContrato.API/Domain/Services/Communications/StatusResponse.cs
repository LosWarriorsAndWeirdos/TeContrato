using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Services.Communications
{
    public class StatusResponse : BaseResponse<Status>
    {
        public StatusResponse(Status resource) : base(resource)
        {
        }

        public StatusResponse(string message) : base(message)
        {
        }
    }
}