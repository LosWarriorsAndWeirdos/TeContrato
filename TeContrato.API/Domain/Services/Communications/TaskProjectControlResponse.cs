using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Services.Communications
{
    public class TaskProjectControlResponse : BaseResponse<TaskProjectControl>
    {
        public TaskProjectControlResponse(TaskProjectControl resource) : base(resource)
        {
        }

        public TaskProjectControlResponse(string message) : base(message)
        {
        }
    }
}